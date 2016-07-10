using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ArtistProfile")]
    internal class ArtistProfileEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Slug { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string ImageFileUrl { get; set; }

        public List<ArtistProfileApplicationUserEntity> Owners { get; set; }

        public List<FollowingEntity> Followers { get; set; }

        public List<ArtistProfileTrackEntity> Tracks { get; set; }

        public List<ArtistProfileGenreEntity> Genres { get; set; }

        public List<ArtistProfileTagEntity> Tags { get; set; }

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
