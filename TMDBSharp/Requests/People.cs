using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class PeopleClient
{
    /// <summary>
    /// Query the top level details of a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Person?> GetDetails(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
        return await BaseRequests.RequestAsync<Person?>($"person/{id}", HttpMethod.Get, parameters);
    }

    /// <summary>
    /// Get the changes for a person. By default only the last 24 hours are returned.
    /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <param name="page"></param>
    /// <param name="end_date"></param>
    /// <param name="start_date"></param>
    /// <returns></returns>
    public async Task<Changes?> GetChanges(
        int id,
        int page = 1,
        DateTime? end_date = null,
        DateTime? start_date = null
    )
    {
        var parameters = BaseRequests.FillBaseparameters(
            page: page,
            end_date: end_date,
            start_date: start_date
        );
        return await BaseRequests.RequestAsync<Changes?>(
            $"person/{id}/changes",
            HttpMethod.Get,
            parameters
        );
    }

    /// <summary>
    /// Get the combined movie and TV credits that belong to a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Casts?> GetCombinedCredits(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
        return await BaseRequests.RequestAsync<Casts?>(
            $"person/{id}/combined_credits",
            HttpMethod.Get,
            parameters
        );
    }

    /// <summary>
    /// Get the external ID's that belong to a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <returns></returns>
    public async Task<ExternalIds?> GetExternalIds(int id)
    {
        return await BaseRequests.RequestAsync<ExternalIds?>(
            $"person/{id}/external_ids",
            HttpMethod.Get
        );
    }

    /// <summary>
    /// Get the profile images that belong to a person.
    /// This method will return the profile images that have been added to a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <returns></returns>
    public async Task<Images?> GetImages(int id)
    {
        return await BaseRequests.RequestAsync<Images>($"movie/{id}/images", HttpMethod.Get);
    }

    /// <summary>
    /// Get the newest created person. This is a live response and will continuously change.
    /// </summary>
    /// <returns></returns>
    public async Task<Person?> GetLatest()
    {
        return await BaseRequests.RequestAsync<Person?>("person/latest", HttpMethod.Get);
    }

    /// <summary>
    /// Get the movie credits for a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Casts?> GetMovieCredits(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
        return await BaseRequests.RequestAsync<Casts?>(
            $"person/{id}/movie_credits",
            HttpMethod.Get,
            parameters
        );
    }

    /// <summary>
    /// Get the TV credits that belong to a person.
    /// </summary>
    /// <param name="id">Person Id</param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<Casts?> GetTVCredits(int id, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(language: language);
        return await BaseRequests.RequestAsync<Casts?>(
            $"person/{id}/tv_credits",
            HttpMethod.Get,
            parameters
        );
    }

    /// <summary>
    /// Get the tagged images for a person.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Image>?> GetTaggedImages(int id, int page = 1)
    {
        var parameters = BaseRequests.FillBaseparameters(page: page);
        return await BaseRequests.RequestAsync<BaseListRequest<Image>?>(
            $"person/{id}/tagged_images",
            HttpMethod.Get,
            parameters
        );
    }

    /// <summary>
    /// Get the translations that belong to a person.
    /// Take a read through our language documentation for more information about languages on TMDB.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Translation>?> GetTranslations(int id)
    {
        return await BaseRequests.RequestAsync<BaseListRequest<Translation>?>(
            $"person/{id}/translations",
            HttpMethod.Get
        );
    }
}
