using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ExternalArtist")]
    internal class ExternalArtistEntity
    {
        [Key]
        public int Id { get; set; }

        public int ExternalSourceId { get; set; }

        public string ExternalId { get; set; }

        public string Name { get; set; }

        public int? Popularity { get; set; }

        public List<ExternalArtistGenreEntity> Genres { get; set; }

        public List<ExternalArtistRelatedArtistEntity> RelatedArtists { get; set; }

        public List<ExternalArtistRelatedArtistEntity> IsRelatedToArtists { get; set; }
    }
}
