using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class MovieClient
{
    public Movie? GetDetails(int id, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return BaseRequests.Request<Movie?>("movie/" + id.ToString(), HttpMethod.Get, parameters);
    }

    public AccountStates? GetAccountStates(int id, string? session_id = null, string? guest_session_id = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"session_id", session_id} ,
            {"guest_session_id", guest_session_id}
        };
        return BaseRequests.Request<AccountStates?>("movie/" + id.ToString() + "/account_states", HttpMethod.Get, parameters);
    }

    public AlternativeTitles? GetAlternativeTitles(int id, string? country = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"country", country}
        };
        return BaseRequests.Request<AlternativeTitles?>("movie/" + id.ToString() + "/alternative_titles", HttpMethod.Get, parameters);
    }

    public Changes? GetChanges(int id, int page = 1, DateTime? end_date = null, DateTime? start_date = null)
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"end_date", end_date},
            {"start_date", start_date},
        };
        return BaseRequests.Request<Changes?>("movie/" + id.ToString() + "/changes", HttpMethod.Get, parameters);
    }

    public Credits? GetCredits(int id, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return BaseRequests.Request<Credits?>("movie/" + id.ToString() + "/credits", HttpMethod.Get, parameters);
    }

    public ExternalIds? GetExternalIds(int id)
    {
        return BaseRequests.Request<ExternalIds?>("movie/" + id.ToString() + "/external_ids", HttpMethod.Get);
    }

    public Images? GetImages(int id)
    {
        return BaseRequests.Request<Images>("movie/" + id.ToString() + "/images", HttpMethod.Get);
    }

    public Keywords? GetKeywords(int id)
    {
        return BaseRequests.Request<Keywords>("movie/" + id.ToString() + "/keyword", HttpMethod.Get);
    }

    public Movie? GetLatest()
    {
        return BaseRequests.Request<Movie>("movie/latest", HttpMethod.Get);
    }

    public BaseListRequest<Lists>? GetLists(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return BaseRequests.Request<BaseListRequest<Lists>>("movie/" + id.ToString() + "/lists", HttpMethod.Get, parameters);
    }

    public BaseListRequest<Movie>? GetRecomendations(int id, int page = 1, string language = "en-US")
    {
        var parameters = new Dictionary<string, object?>
        {
            {"page", page},
            {"language",language},
        };
        return BaseRequests.Request<BaseListRequest<Movie>>("movie/" + id.ToString() + "/recommendations", HttpMethod.Get, parameters);
    }

    public BaseListRequest<ReleaseDates>? GetReleaseDates(int id)
    {
        return BaseRequests.Request<BaseListRequest<ReleaseDates>>("movie/" + id.ToString() + "/release_dates", HttpMethod.Get);
    }
}