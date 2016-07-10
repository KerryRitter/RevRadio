using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ExternalArtist_Genre")]
    internal class ExternalArtistGenreEntity
    {
        public int ExternalArtistId { get; set; }

        [ForeignKey(nameof(ExternalArtistId))]
        public ExternalArtistEntity Artist { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public GenreEntity Genre { get; set; }
    }
}
