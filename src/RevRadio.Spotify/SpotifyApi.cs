using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RevRadio.Spotify.Models;

namespace RevRadio.Spotify
{
    public class SpotifyApi
    {
        public async Task<List<FullArtist>> SearchForArtist(string search)
        {
            var parameters = new Dictionary<string, string>
            {
                { "q", search },
                { "type", "artist" }
            };

            var results = await Get<SearchItem>("search", parameters);

            return results.Artists.Items;
        }

        public async Task<FullArtist> GetArtistById(string id)
        {
            return await Get<FullArtist>($"artists/{id}", null);
        }

        public async Task<List<FullArtist>> GetRelatedArtistByArtistId(string id)
        {
            var results = await Get<SeveralArtists>($"artists/{id}/related-artists", null);

            return results.Artists;
        }

        private static async Task<T> Get<T>(string path, Dictionary<string, string> parameters)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.spotify.com/v1/"),
            };

            var urlEncodedParameters = parameters?.Select(kv => $"{WebUtility.HtmlEncode(kv.Key)}={WebUtility.HtmlEncode(kv.Value)}");
            var queryString = parameters == null ? "" : "?" + string.Join("&", urlEncodedParameters);
            var endpoint = $"{path}{queryString}";

            var result = await client.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
