using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Track_Genre")]
    internal class TrackGenreEntity
    {
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public TrackEntity Track { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public GenreEntity Genre { get; set; }
    }
}
