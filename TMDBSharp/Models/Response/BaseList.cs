using System.Text.Json.Serialization;

namespace TMDBSharp.Models.Response;

public class BaseList<T>
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    [JsonPropertyName("results")]
    public List<T>? Results { get; set; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}