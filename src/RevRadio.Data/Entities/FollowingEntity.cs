using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Following")]
    internal class FollowingEntity
    {
        public int ArtistProfileId { get; set; }

        [ForeignKey(nameof(ArtistProfileId))]
        public ArtistProfileEntity ArtistProfile { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime FollowedDate { get; set; }
    }
}
