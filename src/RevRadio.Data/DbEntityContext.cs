using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RevRadio.Data.Entities;

namespace RevRadio.Data
{
    public class DbEntityContext : IdentityDbContext<ApplicationUser>
    {
        internal DbSet<ArtistProfileEntity> ArtistProfiles { get; set; }
        internal DbSet<GenreEntity> Genres { get; set; }
        internal DbSet<TrackEntity> Tracks { get; set; }
        internal DbSet<TagEntity> Tags { get; set; }
        internal DbSet<ExternalArtistEntity> ExternalArtists { get; set; }
        internal DbSet<FollowingEntity> Followings { get; set; }

        public DbEntityContext(DbContextOptions<DbEntityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FollowingEntity>().HasKey(e => new { e.ArtistProfileId, e.ApplicationUserId });
            builder.Entity<ArtistProfileApplicationUserEntity>().HasKey(e => new { e.ArtistProfileId, e.ApplicationUserId });
            builder.Entity<ArtistProfileTrackEntity>().HasKey(e => new { e.ArtistProfileId, e.TrackId });
            builder.Entity<ArtistProfileGenreEntity>().HasKey(e => new { e.ArtistProfileId, e.GenreId });
            builder.Entity<ArtistProfileTagEntity>().HasKey(e => new { e.ArtistProfileId, e.TagId });

            builder.Entity<ExternalArtistGenreEntity>().HasKey(e => new { e.ExternalArtistId, e.GenreId });
            builder.Entity<ExternalArtistRelatedArtistEntity>().HasKey(e => new { e.ExternalArtist1Id, e.ExternalArtist2Id });
            builder.Entity<ExternalArtistRelatedArtistEntity>()
                .HasOne(c => c.Artist1)
                .WithMany(c => c.RelatedArtists)
                .HasForeignKey(c => c.ExternalArtist1Id);
            builder.Entity<ExternalArtistRelatedArtistEntity>()
                .HasOne(c => c.Artist2)
                .WithMany(c => c.IsRelatedToArtists)
                .HasForeignKey(c => c.ExternalArtist2Id);

            builder.Entity<TrackGenreEntity>().HasKey(e => new { e.TrackId, e.GenreId });
            builder.Entity<TrackTagEntity>().HasKey(e => new { e.TrackId, e.TagId });

            base.OnModelCreating(builder);
        }
    }
}
