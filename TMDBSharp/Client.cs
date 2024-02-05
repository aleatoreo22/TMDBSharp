using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using TMDBSharp.Core.Enum;
using TMDBSharp.Models;
using TMDBSharp.Models.Response;
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