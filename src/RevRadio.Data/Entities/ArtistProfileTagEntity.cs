using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ArtistProfile_Tag")]
    internal class ArtistProfileTagEntity
    {
        public int ArtistProfileId { get; set; }

        [ForeignKey(nameof(ArtistProfileId))]
        public ArtistProfileEntity ArtistProfile { get; set; }

        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public TagEntity Tag { get; set; }
    }
}
