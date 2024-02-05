# TMDBSharp
![GitHub License](https://img.shields.io/github/license/aleatoreo22/TMDBSharp)

#This project uses CSharp!
<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="100" alt="C#"  />
</div>

## ⏲️ Status
-  Get Movies -
    - [x] By id request.
    - [x] Popular request.
    - [x] Now playing request.

## How to use:
###Installation
Visit [nuget.org](https://www.nuget.org/packages/TMDBSharp)
Or install with nuget:
```bash
dotnet add package TMDBSharp
```

###Exemple
```bash
var client = new TMDBSharp.Client({Your TMDB Token});
var popularMovie = client.GetPopularMovie();
foreach (var item in popularMovie.Results)
{
    Console.WriteLine(item.Title);
}
```