using TMDBSharp.Models;

namespace TMDBSharp.Requests;

public class TvSeriesClient
{
    /// <summary>
    /// Get the details of a TV show.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="language"></param>
    /// <param name="append_to_response">comma separated list of endpoints within this namespace, 20 items max</param>
    /// <returns></returns>
    public async Task<TvSerie?> GetDetails(
        int id,
        string language = "en-US",
        string append_to_response = ""
    )
    {
        var parameters = BaseRequests.FillBaseparameters(
            language: language,
            append_to_response: append_to_response
        );
        return await BaseRequests.RequestAsync<TvSerie?>($"tv/{id}", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the rating, watchlist and favourite status.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="session_id"></param>
    /// <param name="guest_session_id"></param>
    /// <returns></returns>
    public async Task<AccountStates?> GetAccountStates(
        int id,
        string session_id = "",
        string guest_session_id = ""
    )
    {
        var parameters = BaseRequests.FillBaseparameters(
            session_id: session_id,
            guest_session_id: guest_session_id
        );
        return await BaseRequests.RequestAsync<AccountStates?>(
            $"tv/{id}/account_states",
            HttpMethod.Get,
            parameters
        );
    }
}
