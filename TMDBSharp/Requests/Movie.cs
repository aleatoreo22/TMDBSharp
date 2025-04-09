using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class MovieClient
{
    /// <summary>
    /// Get the top level details of a movie by ID.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Movie?> GetDetails(int id, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return await BaseRequests.RequestAsync<Movie?>($"movie/{id}", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the rating, watchlist and favourite status of an account.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="session_id"></param>
    /// <param name="guest_session_id"></param>
    /// <returns></returns>
    public async Task<AccountStates?> GetAccountStates(int id, string? session_id = null,
        string? guest_session_id = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"session_id", session_id},
            {"guest_session_id", guest_session_id}
        };
        return await BaseRequests.RequestAsync<AccountStates?>($"movie/{id}/account_states",
            HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the alternative titles for a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="country"></param>
    /// <returns></returns>
    public async Task<AlternativeTitles?> GetAlternativeTitles(int id, string? country = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"country", country}
        };
        return await BaseRequests.RequestAsync<AlternativeTitles?>($"movie/{id}/alternative_titles",
            HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the changes for a movie.
    /// By default only the last 24 hours are returned.
    /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="page"></param>
    /// <param name="end_date"></param>
    /// <param name="start_date"></param>
    /// <returns></returns>
    public async Task<Changes?> GetChanges(int id, int page = 1, DateTime? end_date = null, DateTime? start_date = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"end_date", end_date},
            {"start_date", start_date},
        };
        return await BaseRequests.RequestAsync<Changes?>($"movie/{id}/changes", HttpMethod.Get, parameters);
    }

    public async Task<Credits?> GetCredits(int id, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return await BaseRequests.RequestAsync<Credits?>($"movie/{id}/credits", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Supported IDs from IMDb, Facebook, Wikidata, Instagram and Twitter
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    public async Task<ExternalIds?> GetExternalIds(int id)
    {
        return await BaseRequests.RequestAsync<ExternalIds?>($"movie/{id}/external_ids", HttpMethod.Get);
    }

    /// <summary>
    /// Get the images that belong to a movie.
    /// This method will return the backdrops, posters and logos that have been added to a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    public async Task<Images?> GetImages(int id)
    {
        return await BaseRequests.RequestAsync<Images>($"movie/{id}/images", HttpMethod.Get);
    }

    public async Task<Keywords?> GetKeywords(int id)
    {
        return await BaseRequests.RequestAsync<Keywords>($"movie/{id}/keyword", HttpMethod.Get);
    }

    /// <summary>
    /// Get the newest movie ID.
    /// This is a live response and will continuously change.
    /// </summary>
    /// <returns></returns>
    public async Task<Movie?> GetLatest()
    {
        return await BaseRequests.RequestAsync<Movie>("movie/latest", HttpMethod.Get);
    }

    /// <summary>
    /// Get the lists that a movie has been added to.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Lists>?> GetLists(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return await BaseRequests.RequestAsync<BaseListRequest<Lists>>($"movie/{id}/lists", HttpMethod.Get, parameters);
    }

    public async Task<BaseListRequest<Movie>?> GetRecomendations(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/recommendations", HttpMethod.Get,
            parameters);
    }

    /// <summary>
    /// Get the release dates and certifications for a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    public async Task<BaseListRequest<ReleaseDates>?> GetReleaseDates(int id)
    {
        return await BaseRequests.RequestAsync<BaseListRequest<ReleaseDates>>($"movie/{id}/release_dates",
            HttpMethod.Get);
    }
}