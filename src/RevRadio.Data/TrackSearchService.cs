using System.Collections.Generic;
using System.Data;
using Dapper;
using RevRadio.Data.Interfaces;
using RevRadio.Data.Models;
using System.Linq;

namespace RevRadio.Data
{
    public class TrackSearchService
    {
        private readonly IDbDapperContextFactory _contextFactory;

        public TrackSearchService(IDbDapperContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Track> Search(string query)
        {
            using (var context = _contextFactory.Create())
            {
                return context.Query<Track>("SearchTracks", new {query = query}, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
