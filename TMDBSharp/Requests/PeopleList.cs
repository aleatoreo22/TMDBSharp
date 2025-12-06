using TMDBSharp.Models;
using TMDBSharp.Models.Response;

namespace TMDBSharp.Requests;

public class PeopleListClient
{
    /// <summary>
    /// Get a list of people ordered by popularity.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public async Task<BaseListRequest<Person>?> GetPopular(int page = 1, string language = "en-US")
    {
        var parameters = BaseRequests.FillBaseparameters(page: page, language: language);
        return await BaseRequests.RequestAsync<BaseListRequest<Person>>(
            $"person/popular",
            HttpMethod.Get,
            parameters
        );
    }
}
