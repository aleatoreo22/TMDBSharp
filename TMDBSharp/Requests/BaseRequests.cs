using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TMDBSharp.Core.Enum;
using static TMDBSharp.Core.Env;

namespace TMDBSharp.Requests;

internal static class BaseRequests
{
    internal static async Task<R?> RequestAsync<R>(string endPoint, HttpMethod method, Dictionary<string, object?>? parameters = null) =>
        await RequestAsync<object, R>(null, endPoint, method, parameters);

    internal static async Task<R?> RequestAsync<T, R>(T? model, string endPoint, HttpMethod method,
        Dictionary<string, object?>? parameters = null)
    {
        parameters = RemoveNullparameters(parameters);
        if (parameters != null && parameters.Count > 0)
            endPoint = parameters.Aggregate(endPoint, (current, item) => current + "?" +
                item.Key + "=" + item.Value?.ToString());
        var httpRequest = new HttpRequestMessage(method, BASE_URL + endPoint);
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var response = new HttpResponseMessage();

        if (method == HttpMethod.Get)
            response = await new HttpClient().SendAsync(httpRequest);
        try
        {
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response?.Content?.ToString());
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<R>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(response.Content.ToString());
            throw;
        }
    }

    internal static Dictionary<string, object?> FillBaseparameters(int? page = null, string? language = null,
        string? sort_by = null, bool? include_adult = null, bool? include_video = null,
        List<RelaseTypes?>? with_release_type = null, string? region = null, string? session_id = null,
        string? guest_session_id = null, string? country = null, DateTime? end_date = null, DateTime? start_date = null,
        string? include_image_language = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {nameof(page), page},
            {nameof(language), language},
            {nameof(sort_by), sort_by},
            {nameof(include_video), include_video},
            {nameof(include_adult), include_adult},
            {nameof(region), region},
            {nameof(session_id), session_id},
            {nameof(guest_session_id), guest_session_id},
            {nameof(country), country},
            {nameof(end_date), end_date},
            {nameof(start_date), start_date},
            {nameof(include_image_language), include_image_language},
        };
        if (with_release_type != null && with_release_type.Count > 0)
            parameters.Add("with_release_type", string.Join("|", with_release_type?.Where(x => x != null)?.
                Select(x => x.GetHashCode())));
        return parameters;
    }


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
}