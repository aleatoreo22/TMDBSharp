using System.Xml.Schema;
using TMDBSharp.Core.Enum;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class MovieLists
{
    public BaseList<Movie>? MovieListsGetPopular(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null)
    {
        var paramters = BaseRequests.FillBaseParamters(page, language, sort_by, include_adult, include_video);
        return BaseRequests.Request<BaseList<Movie>>("movie/popular", HttpMethod.Get, paramters);
    }
    public BaseList<Movie>? MovieListsGetNowPlaying(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null, List<RelaseTypes?>? with_release_type = null)
    {
        var parameters = BaseRequests.FillBaseParamters(page, language, sort_by, include_adult, include_video, with_release_type);
        return BaseRequests.Request<BaseList<Movie>>("discover/movie", HttpMethod.Get, parameters);
    }
}