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

    public async Task<AccountStates?> GetAccountStates(int id, string? session_id = null, string? guest_session_id = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"session_id", session_id} ,
            {"guest_session_id", guest_session_id}
        };
        return await BaseRequests.RequestAsync<AccountStates?>("movie/" + id.ToString() + "/account_states", HttpMethod.Get, parameters);
    }

    public async Task<AlternativeTitles?> GetAlternativeTitles(int id, string? country = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"country", country}
        };
        return await BaseRequests.RequestAsync<AlternativeTitles?>("movie/" + id.ToString() + "/alternative_titles", HttpMethod.Get, parameters);
    }

    public async Task<Changes?> GetChanges(int id, int page = 1, DateTime? end_date = null, DateTime? start_date = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"end_date", end_date},
            {"start_date", start_date},
        };
        return await BaseRequests.RequestAsync<Changes?>("movie/" + id.ToString() + "/changes", HttpMethod.Get, parameters);
    }

    public async Task<Credits?> GetCredits(int id, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return await BaseRequests.RequestAsync<Credits?>("movie/" + id.ToString() + "/credits", HttpMethod.Get, parameters);
    }

    public async Task<ExternalIds?> GetExternalIds(int id)
    {
        return await BaseRequests.RequestAsync<ExternalIds?>("movie/" + id.ToString() + "/external_ids", HttpMethod.Get);
    }

    public async Task<Images?> GetImages(int id)
    {
        return await BaseRequests.RequestAsync<Images>("movie/" + id.ToString() + "/images", HttpMethod.Get);
    }

    public async Task<Keywords?> GetKeywords(int id)
    {
        return await BaseRequests.RequestAsync<Keywords>("movie/" + id.ToString() + "/keyword", HttpMethod.Get);
    }

    public async Task<Movie?> GetLatest()
    {
        return await BaseRequests.RequestAsync<Movie>("movie/latest", HttpMethod.Get);
    }

    public async Task<BaseListRequest<Lists>?> GetLists(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return await BaseRequests.RequestAsync<BaseListRequest<Lists>>("movie/" + id.ToString() + "/lists", HttpMethod.Get, parameters);
    }

    public async Task<BaseListRequest<Movie>?> GetRecomendations(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>("movie/" + id.ToString() + "/recommendations", HttpMethod.Get, parameters);
    }

    public async Task<BaseListRequest<ReleaseDates>?> GetReleaseDates(int id)
    {
        return await BaseRequests.RequestAsync<BaseListRequest<ReleaseDates>>("movie/" + id.ToString() + "/release_dates", HttpMethod.Get);
    }
}