using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RevRadio.Data.Entities;

namespace RevRadio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal DbSet<ArtistProfileEntity> ArtistProfiles { get; set; }
        internal DbSet<GenreEntity> Genres { get; set; }
        internal DbSet<TrackEntity> Tracks { get; set; }
        internal DbSet<TagEntity> Tags { get; set; }

        internal DbSet<ArtistProfileApplicationUserEntity> ArtistProfileApplicationUsers { get; set; }
        internal DbSet<ArtistProfileTagEntity> ArtistProfileTags { get; set; }
        internal DbSet<FollowingEntity> Followings { get; set; }
        internal DbSet<ArtistProfileTrackEntity> ArtistProfileTracks { get; set; }
        internal DbSet<TrackGenreEntity> TrackGenres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArtistProfileApplicationUserEntity>().HasKey(e => new { e.ArtistProfileId, e.ApplicationUserId });
            builder.Entity<FollowingEntity>().HasKey(e => new { e.ArtistProfileId, e.ApplicationUserId });
            builder.Entity<ArtistProfileTrackEntity>().HasKey(e => new { e.ArtistProfileId, e.TrackId });
            builder.Entity<TrackGenreEntity>().HasKey(e => new { e.TrackId, e.GenreId });
            builder.Entity<ArtistProfileTagEntity>().HasKey(e => new { e.ArtistProfileId, e.TagId });

            base.OnModelCreating(builder);
        }
    }
}
