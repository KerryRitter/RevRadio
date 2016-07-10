using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace RevRadio.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        internal List<ArtistProfileApplicationUserEntity> ArtistProfiles { get; set; }

        internal List<FollowingEntity> Following { get; set; }
    }
}
