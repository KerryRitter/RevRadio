using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ArtistProfile_Genre")]
    internal class ArtistProfileGenreEntity
    {
        public int ArtistProfileId { get; set; }

        [ForeignKey(nameof(ArtistProfileId))]
        public ArtistProfileEntity Artist { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public GenreEntity Genre { get; set; }
    }
}
