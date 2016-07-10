using System.Collections.Generic;
using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class SeveralTracks : BasicModel
    {
        [JsonProperty("tracks")]
        public List<FullTrack> Tracks { get; set; }
    }
}