using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class Snapshot : BasicModel
    {
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }
    }
}