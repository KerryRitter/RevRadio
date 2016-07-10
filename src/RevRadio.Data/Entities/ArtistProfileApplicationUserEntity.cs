using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("ArtistProfile_ApplicationUser")]
    internal class ArtistProfileApplicationUserEntity
    {
        public int ArtistProfileId { get; set; }

        [ForeignKey(nameof(ArtistProfileId))]
        public ArtistProfileEntity ArtistProfile { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
