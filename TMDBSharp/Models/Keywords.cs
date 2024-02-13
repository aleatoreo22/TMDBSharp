using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Keywords
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("keywords")]
        public List<Keyword>? Keyword { get; set; }
    }
}