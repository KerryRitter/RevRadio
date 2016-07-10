using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class FeaturedPlaylists : BasicModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("playlists")]
        public Paging<SimplePlaylist> Playlists { get; set; }
    }
}