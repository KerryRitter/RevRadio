using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace RevRadio.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<ArtistProfileApplicationUserEntity> ArtistProfiles { get; set; }

        public List<FollowingEntity> Following { get; set; }
    }
}
