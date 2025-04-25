using DotNetEnv;
using TMDBSharp.Requests;

namespace TMDBSharp.Test;

public class MovieTest
{
    Client client;
    const int MOVIE_ID = 950387;

    [SetUp]
    public void Setup()
    {
        var execPath = AppDomain.CurrentDomain.BaseDirectory;
        var solutionPath = execPath[..(execPath.IndexOf("TMDBSharp") + 10)];
        Env.Load(solutionPath + ".env");
        var token = Env.GetString("TMDB_TOKEN");
        client = new Client(token);
    }

    [Test]
    public async Task GetDetails()
    {
        var response = await client.Movie.GetDetails(MOVIE_ID);
        Assert.That(response?.Title, Is.Not.EqualTo(null));
    }
}
