using System.Xml.Schema;
using TMDBSharp.Core.Enum;
using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class MovieListsClient
{
    public BaseList<Movie>? GetPopular(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null)
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, sort_by, include_adult, include_video);
        return BaseRequests.Request<BaseList<Movie>>("movie/popular", HttpMethod.Get, parameters);
    }
    public BaseList<Movie>? GetNowPlaying(int page = 1, string language = "en-US", string? sort_by = null, bool? include_adult = null, bool? include_video = null, List<RelaseTypes?>? with_release_type = null)
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, sort_by, include_adult, include_video, with_release_type);
        return BaseRequests.Request<BaseList<Movie>>("discover/movie", HttpMethod.Get, parameters);
    }
}