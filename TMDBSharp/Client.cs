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

    private Requests.PeopleClient? people = null;
    public Requests.PeopleClient People
    {
        get
        {
            people ??= new Requests.PeopleClient();
            return people;
        }
    }

    private Requests.PeopleListClient? peopleList = null;
    public Requests.PeopleListClient PeopleList
    {
        get
        {
            peopleList ??= new Requests.PeopleListClient();
            return peopleList;
        }
    }
}
