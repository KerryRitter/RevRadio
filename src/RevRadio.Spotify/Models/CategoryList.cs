using Newtonsoft.Json;

namespace RevRadio.Spotify.Models
{
    public class CategoryList : BasicModel
    {
        [JsonProperty("categories")]
        public Paging<Category> Categories { get; set; }
    }
}