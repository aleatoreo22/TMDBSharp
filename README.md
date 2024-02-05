# TMDBSharp
![GitHub License](https://img.shields.io/github/license/aleatoreo22/TMDBSharp)

#This project uses CSharp!
<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="100" alt="C#"  />
</div>

# ⏲️ [Status](STATUS.md)
Movies 🛠️
People 🔜
TV Series 🔜
Trending 🔜
TV Seasons 🔜
TV Episodes 🔜
Watch Providers 🔜
## How to use:
###Installation
Visit [nuget.org](https://www.nuget.org/packages/TMDBSharp)
Or install with nuget:
```bash
dotnet add package TMDBSharp
```

###Exemple
```bash
var client =new TMDBSharp.Client("");
var popularMovies = client.MovieLists.GetPopular();
foreach (var item in popularMovies.Results)
{
    Console.WriteLine(item.Title);
}
```