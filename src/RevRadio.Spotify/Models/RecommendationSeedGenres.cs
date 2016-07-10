using System.Collections.Generic;
using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class RecommendationSeedGenres : BasicModel
    {
         [JsonProperty("genres")]
         public List<string> Genres { get; set; }
    }
}