using System.Net;
using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public abstract class BasicModel
    {
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}