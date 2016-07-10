using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Tag")]
    internal class TagEntity
    {
        [Key]
        public int Id { get; set; }

        public int ExternalArtistId { get; set; }

        [ForeignKey(nameof(ExternalArtistId))]
        public ExternalArtistEntity ExternalArtist { get; set; }

        public List<ArtistProfileTagEntity> ArtistProfiles { get; set; }
    }
}
