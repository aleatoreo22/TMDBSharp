using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class MovieListsClient
{

    /// <summary>
    /// Get a list of all of the movie ids that have been changed in the past 24 hours.
    /// You can query this method up to 14 days at a time. Use the start_date and end_date query parameters. 100 items are returned per page.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <param name="region">ISO-3166-1 code</param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetPopular(int page = 1, string language = "en-US",
        string? region = null)
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, region: region);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>("movie/popular", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get a list of movies that are currently in theatres.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <param name="region">ISO-3166-1 code</param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetNowPlaying(int page = 1, string language = "en-US",
        string? region = null)
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, region: region);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>?>("movie/now_playing", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get a list of movies ordered by rating.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <param name="region">ISO-3166-1 code</param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetTopRated(int page = 1, string language = "en-US", string region = "")
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, region: region);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>?>("movie/top_rated", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get a list of movies that are being released soon.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <param name="region">ISO-3166-1 code</param>
    public async Task<BaseListRequest<Movie>?> GetUpcoming(int page = 1, string language = "en-US", string region = "")
    {
        var parameters = BaseRequests.FillBaseparameters(page, language, region: region);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>?>("movie/upcoming", HttpMethod.Get, parameters);
    }
}


