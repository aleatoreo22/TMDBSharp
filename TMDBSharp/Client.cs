using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using TMDBSharp.Core.Enum;
using TMDBSharp.Models;
using TMDBSharp.Models.Response;
using static TMDBSharp.Core.Env;

namespace TMDBSharp;

public class Client
{
    public Client(string token)
    {
        Token = token;
    }

    #region  Movie
    public Movie? GetMovieDetails(int id, string language = "en-US")
    {
        var paramters = new Dictionary<string, object?>
        {
            {"language", language}
        };

        return RequestBase<Movie>("movie/" + id.ToString(), HttpMethod.Get, paramters);
    }
    public BaseList<Movie>? GetPopularMovie(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null)
    {
        var paramters = new Dictionary<string, object?>
        {
            { "page", page },
            {"language", language},
            {"sort_by", sort_by},
            {"include_video", include_video},
            {"include_adult", include_adult},
        };
        return RequestBase<BaseList<Movie>>("movie/popular", HttpMethod.Get, paramters);
    }
    public BaseList<Movie>? GetNowPlaying(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null, List<RelaseTypes?>? with_release_type = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language", language},
            {"sort_by", sort_by},
            {"include_video", include_video},
            {"include_adult", include_adult},
            {"with_release_type", string.Join("|", with_release_type?.Where(x => x != null)?.Select(x => x.GetHashCode()))}
        };
        return RequestBase<BaseList<Movie>>("discover/movie", HttpMethod.Get, parameters);
    }
    #endregion

    #region Base
    private R? RequestBase<R>(string endPoint, HttpMethod method, Dictionary<string, object?>? parameters = null) => RequestBase<object, R>(null, endPoint, method, parameters);

    private Dictionary<string, object?>? RemoveNullParamters(Dictionary<string, object?>? paramters)
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

    private R? RequestBase<T, R>(T? model, string endPoint, HttpMethod method,
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
    #endregion
}