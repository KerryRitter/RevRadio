using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Genre")]
    public class GenreEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<TrackGenreEntity> Tracks { get; set; }
    }
}
