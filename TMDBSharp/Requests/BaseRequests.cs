using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.Json;
using TMDBSharp.Core.Enum;
using static TMDBSharp.Core.Env;

namespace TMDBSharp.Requests;

internal static class BaseRequests
{
    internal static Dictionary<string, object?> FillBaseparameters(int? page = null, string? language = null, string? sort_by = null, bool? include_adult = null, bool? include_video = null, List<RelaseTypes?>? with_release_type = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language", language},
            {"sort_by", sort_by},
            {"include_video", include_video},
            {"include_adult", include_adult},
        };
        if (with_release_type != null && with_release_type.Count > 0)
            parameters.Add("with_release_type", string.Join("|", with_release_type?.Where(x => x != null)?.Select(x => x.GetHashCode())));
        return parameters;
    }

    internal static R? Request<R>(string endPoint, HttpMethod method, Dictionary<string, object?>? parameters = null) => Request<object, R>(null, endPoint, method, parameters);

    internal static Dictionary<string, object?>? RemoveNullparameters(Dictionary<string, object?>? parameters)
    {
        try
        {
            if (parameters == null)
                return null;
            var notNullparameters = new Dictionary<string, object?>();
            foreach (var item in parameters.Keys)
            {
                if (parameters[item] != null)
                    notNullparameters.Add(item, parameters[item]);
            }
            return notNullparameters;
        }
        catch (Exception)
        {
            throw;
        }
    }

    internal static R? Request<T, R>(T? model, string endPoint, HttpMethod method,
        Dictionary<string, object?>? parameters = null)
    {
        parameters = RemoveNullparameters(parameters);
        if (parameters != null && parameters.Count > 0)
            endPoint = parameters.Aggregate(endPoint, (current, item) => current + "?" + item.Key + "=" + item.Value?.ToString());
        var httpRequest = new HttpRequestMessage(method, BASE_URL + endPoint);
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var response = new HttpResponseMessage();

        if (method == HttpMethod.Get)
        {
            response = new HttpClient().SendAsync(httpRequest).Result;
        }
        try
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.Content.ToString());
            return JsonSerializer.Deserialize<R>(response.Content.ReadAsStringAsync().Result.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}