using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RevRadio.Spotify;
using RevRadio.Spotify.Models;
using System.Collections.Generic;

namespace RevRadio.Apis
{
    public class SpotifyController : Controller
    {
        public async Task<List<FullArtist>> Search(string q)
        {
            return await (new SpotifyApi()).SearchForArtist(q);
        }

        public async Task<FullArtist> Get(string id)
        {
            return await (new SpotifyApi()).GetArtistById(id);
        }

        public async Task<List<FullArtist>> GetRelated(string id)
        {
            return await (new SpotifyApi()).GetRelatedArtistByArtistId(id);
        }
    }
}