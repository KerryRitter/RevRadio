using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Track")]
    public class TrackEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ReleaseTitle { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string AudioFileUrl { get; set; }

        public string ImageFileUrl { get; set; }

        public int ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public ArtistProfileEntity Artist { get; set; }

        public List<TrackGenreEntity> Genres { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser CreatedBy { get; set; }

        public string LastModifiedById { get; set; }

        [ForeignKey(nameof(LastModifiedById))]
        public ApplicationUser LastModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
