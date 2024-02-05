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

    private Requests.Movie? movie = null;
    public Requests.Movie Movie
    {
        get
        {
            movie ??= new Requests.Movie();
            return movie;
        }
    }

    private Requests.MovieLists? movieLists = null;
    public Requests.MovieLists MovieLists
    {
        get
        {
            movieLists ??= new Requests.MovieLists();
            return movieLists;
        }
    }
}