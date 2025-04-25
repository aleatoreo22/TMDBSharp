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
        var parameters = BaseRequests.FillBaseparameters(language: language);
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
        var parameters = BaseRequests.FillBaseparameters(session_id: session_id, guest_session_id: guest_session_id);
        return await BaseRequests.RequestAsync<AccountStates?>($"movie/{id}/account_states",
            HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the alternative titles for a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="country">specify a ISO-3166-1 value to filter the results</param>
    /// <returns></returns>
    public async Task<AlternativeTitles?> GetAlternativeTitles(int id, string? country = null)
    {
        var parameters = BaseRequests.FillBaseparameters(country: country);
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
        var parameters = BaseRequests.FillBaseparameters(page: page, end_date: end_date, start_date: start_date);
        return await BaseRequests.RequestAsync<Changes?>($"movie/{id}/changes", HttpMethod.Get, parameters);
    }

    public async Task<Credits?> GetCredits(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
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
    /// <param name="language"></param>
    /// <param name="include_image_language">specify a comma separated list of ISO-639-1 values to query, for example: en,null</param>
    /// <returns></returns>
    public async Task<Images?> GetImages(int id, string? language = null, string? include_image_language = null)
    {
        var parameters = BaseRequests.FillBaseparameters(language: language,
            include_image_language: include_image_language);
        return await BaseRequests.RequestAsync<Images>($"movie/{id}/images", HttpMethod.Get, parameters);
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
        var parameters = BaseRequests.FillBaseparameters(page: page, language: language);
        return await BaseRequests.RequestAsync<BaseListRequest<Lists>>($"movie/{id}/lists", HttpMethod.Get, parameters);
    }

    public async Task<BaseListRequest<Movie>?> GetRecomendations(int id, int page = 1, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(page: page, language: language);
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

    /// <summary>
    /// Get the user reviews for a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetReviews(int id, int page = 1, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(page: page, language: language);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/reviews", HttpMethod.Get,
            parameters);
    }

    /// <summary>
    /// Get the similar movies based on genres and keywords.
    /// This method only looks for other items based on genres and plot keywords. As such, the results found here are not always going to be 💯. Use it with that in mind.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetSimilar(int id, int page = 1, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(page: page, language: language);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/similar", HttpMethod.Get,
            parameters);
    }

    /// <summary>
    /// Get the translations for a movie.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetTranslations(int id)
    {
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/similar", HttpMethod.Get);
    }

    public async Task<BaseListRequest<Movie>?> GetVideos(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/videos", HttpMethod.Get,
            parameters);
    }

    /// <summary>
    /// Get the list of streaming providers we have for a movie.
    /// Powered by our partnership with JustWatch, you can query this method to get a list of the streaming/rental/purchase availabilities per country by provider.
    /// This is not going to return full deep links, but rather, it's just enough information to display what's available where.
    /// You can link to the provided TMDB URL to help support TMDB and provide the actual deep links to the content.
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    public async Task<BaseListRequest<Movie>?> GetWatchProviders(int id)
    {
        return await BaseRequests.RequestAsync<BaseListRequest<Movie>>($"movie/{id}/similar", HttpMethod.Get);
    }
}