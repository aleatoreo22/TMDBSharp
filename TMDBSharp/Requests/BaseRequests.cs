using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TMDBSharp.Core.Enum;
using static TMDBSharp.Core.Env;

namespace TMDBSharp.Requests;

internal static class BaseRequests
{
    internal static Dictionary<string, object?> FillBaseParamters(int? page = null, string? language = null, string? sort_by = null, bool? include_adult = null, bool? include_video = null, List<RelaseTypes?>? with_release_type = null)
    {
        return new Dictionary<string, object?>
        {
            {"page", page},
            {"language", language},
            {"sort_by", sort_by},
            {"include_video", include_video},
            {"include_adult", include_adult},
            {"with_release_type", string.Join("|", with_release_type?.Where(x => x != null)?.Select(x => x.GetHashCode()))}
        };
    }

    internal static R? Request<R>(string endPoint, HttpMethod method, Dictionary<string, object?>? parameters = null) => Request<object, R>(null, endPoint, method, parameters);

    internal static Dictionary<string, object?>? RemoveNullParamters(Dictionary<string, object?>? paramters)
    {
        try
        {
            if (paramters == null)
                return null;
            var notNullParamters = new Dictionary<string, object?>();
            foreach (var item in paramters.Keys)
            {
                if (paramters[item] != null)
                    notNullParamters.Add(item, paramters[item]);
            }
            return notNullParamters;
        }
        catch (Exception)
        {
            throw;
        }
    }

    internal static R? Request<T, R>(T? model, string endPoint, HttpMethod method,
        Dictionary<string, object?>? parameters = null)
    {
        parameters = RemoveNullParamters(parameters);
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