using System.ComponentModel.DataAnnotations.Schema;

namespace RevRadio.Data.Entities
{
    [Table("Track_Tag")]
    internal class TrackTagEntity
    {
        public int TrackId { get; set; }

        [ForeignKey("TrackId")]
        public TrackEntity Track { get; set; }

        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public TagEntity Tag { get; set; }
    }
}
