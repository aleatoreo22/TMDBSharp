using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class AccountStates
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("favorite")]
        public bool? Favorite { get; set; }
        [JsonPropertyName("rated")]
        public bool? Rated { get; set; }
        [JsonPropertyName("watchlist")]
        public bool? Watchlist { get; set; }

    }
}