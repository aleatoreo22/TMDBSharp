namespace TMDBSharp.Requests;

public class Movie
{
    public Movie? MovieGetDetails(int id, string language = "en-US")
    {
        var paramters = new Dictionary<string, object?>
        {
            {"language", language}
        };
        return BaseRequests.Request<Movie>("movie/" + id.ToString(), HttpMethod.Get, paramters);
    }
}