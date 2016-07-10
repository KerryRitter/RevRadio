using System;
using System.Collections.Generic;

namespace RevRadio.Data.Models
{
    public class Track
    {
        public string Title { get; set; }

        public string ReleaseTitle { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AudioFileUrl { get; set; }

        public string ImageFileUrl { get; set; }

        public ArtistProfile Artist { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
