using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ExternalArtistRelatedArtist")]
    internal class ExternalArtistRelatedArtistEntity
    {
        public int ExternalArtist1Id { get; set; }
        public ExternalArtistEntity Artist1 { get; set; }

        public int ExternalArtist2Id { get; set; }
        public ExternalArtistEntity Artist2 { get; set; }
    }
}
