using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Changes
    {
        [JsonPropertyName("changes")]
        public List<Change>? Change { get; set; }
    }
}