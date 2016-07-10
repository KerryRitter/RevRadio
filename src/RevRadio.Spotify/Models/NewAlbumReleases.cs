using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class NewAlbumReleases : BasicModel
    {
        [JsonProperty("albums")]
        public Paging<SimpleAlbum> Albums { get; set; }
    }
}