using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Credits
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("cast")]
        public List<Cast>? Casts { get; set; }
        [JsonPropertyName("crew")]
        public List<Crew>? Crews { get; set; }
    }
}