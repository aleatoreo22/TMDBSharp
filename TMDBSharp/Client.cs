using static TMDBSharp.Core.Env;

namespace TMDBSharp;

public class Client
{
    public Client(string token)
    {
        Token = token;
    }

    private Requests.MovieClient? movie = null;
    public Requests.MovieClient Movie
    {
        get
        {
            movie ??= new Requests.MovieClient();
            return movie;
        }
    }

    private Requests.MovieListsClient? movieLists = null;
    public Requests.MovieListsClient MovieLists
    {
        get
        {
            movieLists ??= new Requests.MovieListsClient();
            return movieLists;
        }
    }
}