using RevRadio.Data.Entities;
using System.Collections.Generic;

namespace RevRadio.Data.Models
{
    public class ArtistProfile
    {
        public string Slug { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ImageFileUrl { get; set; }

        public List<Genre> Genres { get; set; }

        public ApplicationUser CreatedBy { get; set; }

        public List<ApplicationUser> Owners { get; set; }

        public List<ApplicationUser> Followers { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
