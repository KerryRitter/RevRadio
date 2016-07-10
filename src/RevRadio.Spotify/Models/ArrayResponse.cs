using System.Collections.Generic;

namespace RevRadio.Spotify.Models
{
    public class ListResponse<T> : BasicModel
    {
        public List<T> List { get; set; }
    }
}