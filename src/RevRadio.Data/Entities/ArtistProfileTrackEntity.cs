using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ArtistProfile_Track")]
    public class ArtistProfileTrackEntity
    {
        public int ArtistProfileId { get; set; }

        [ForeignKey(nameof(ArtistProfileId))]
        public ArtistProfileEntity ArtistProfile { get; set; }

        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public TrackEntity Track { get; set; }
    }
}
