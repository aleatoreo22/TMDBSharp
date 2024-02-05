using TMDBSharp.Models;

namespace TMDBSharp.Requests;

public class MovieClient
{
    public Movie? GetDetails(int id, string language = "en-US")
    {
        var paramters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return BaseRequests.Request<Movie>("movie/" + id.ToString(), HttpMethod.Get, paramters);
    }
}