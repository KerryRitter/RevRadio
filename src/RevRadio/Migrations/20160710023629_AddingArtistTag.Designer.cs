using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RevRadio.Data;

namespace RevRadio.Migrations
{
    [DbContext(typeof(DbEntityContext))]
    [Migration("20160710023629_AddingArtistTag")]
    partial class AddingArtistTag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileApplicationUserEntity", b =>
                {
                    b.Property<int>("ArtistProfileId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("ArtistProfileId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ArtistProfileId");

                    b.ToTable("ArtistProfile_ApplicationUser");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ImageFileUrl");

                    b.Property<string>("LastModifiedById");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 16);

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("ArtistProfile");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileTagEntity", b =>
                {
                    b.Property<int>("ArtistProfileId");

                    b.Property<int>("TagId");

                    b.HasKey("ArtistProfileId", "TagId");

                    b.HasIndex("ArtistProfileId");

                    b.HasIndex("TagId");

                    b.ToTable("ArtistProfile_Tag");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileTrackEntity", b =>
                {
                    b.Property<int>("ArtistProfileId");

                    b.Property<int>("TrackId");

                    b.HasKey("ArtistProfileId", "TrackId");

                    b.HasIndex("ArtistProfileId");

                    b.HasIndex("TrackId");

                    b.ToTable("ArtistProfile_Track");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.FollowingEntity", b =>
                {
                    b.Property<int>("ArtistProfileId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("FollowedDate");

                    b.HasKey("ArtistProfileId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ArtistProfileId");

                    b.ToTable("Following");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Slug")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.TagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.TrackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<string>("AudioFileUrl")
                        .IsRequired();

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ImageFileUrl");

                    b.Property<string>("LastModifiedById");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<string>("ReleaseTitle");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.TrackGenreEntity", b =>
                {
                    b.Property<int>("TrackId");

                    b.Property<int>("GenreId");

                    b.HasKey("TrackId", "GenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("TrackId");

                    b.ToTable("Track_Genre");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileApplicationUserEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.ArtistProfileEntity", "ArtistProfile")
                        .WithMany("Owners")
                        .HasForeignKey("ArtistProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileTagEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ArtistProfileEntity", "ArtistProfile")
                        .WithMany("Tags")
                        .HasForeignKey("ArtistProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.TagEntity", "Tag")
                        .WithMany("ArtistProfiles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RevRadio.Data.Entities.ArtistProfileTrackEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ArtistProfileEntity", "ArtistProfile")
                        .WithMany("Tracks")
                        .HasForeignKey("ArtistProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.TrackEntity", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RevRadio.Data.Entities.FollowingEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.ArtistProfileEntity", "ArtistProfile")
                        .WithMany("Followers")
                        .HasForeignKey("ArtistProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RevRadio.Data.Entities.TrackEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.ArtistProfileEntity", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("RevRadio.Data.Entities.ApplicationUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById");
                });

            modelBuilder.Entity("RevRadio.Data.Entities.TrackGenreEntity", b =>
                {
                    b.HasOne("RevRadio.Data.Entities.GenreEntity", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RevRadio.Data.Entities.TrackEntity", "Track")
                        .WithMany("Genres")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
