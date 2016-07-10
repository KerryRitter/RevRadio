using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RevRadio.Migrations
{
    public partial class AddingArtistProfilesAndTracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ImageFileUrl = table.Column<string>(nullable: true),
                    LastModifiedById = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(maxLength: 16, nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistProfile_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistProfile_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Slug = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistProfile_ApplicationUser",
                columns: table => new
                {
                    ArtistProfileId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistProfile_ApplicationUser", x => new { x.ArtistProfileId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ArtistProfile_ApplicationUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistProfile_ApplicationUser_ArtistProfile_ArtistProfileId",
                        column: x => x.ArtistProfileId,
                        principalTable: "ArtistProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    ArtistProfileId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    FollowedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => new { x.ArtistProfileId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_Following_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Following_ArtistProfile_ArtistProfileId",
                        column: x => x.ArtistProfileId,
                        principalTable: "ArtistProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(nullable: false),
                    AudioFileUrl = table.Column<string>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ImageFileUrl = table.Column<string>(nullable: true),
                    LastModifiedById = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    ReleaseTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_ArtistProfile_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "ArtistProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_AspNetUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistProfile_Track",
                columns: table => new
                {
                    ArtistProfileId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistProfile_Track", x => new { x.ArtistProfileId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_ArtistProfile_Track_ArtistProfile_ArtistProfileId",
                        column: x => x.ArtistProfileId,
                        principalTable: "ArtistProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistProfile_Track_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Track_Genre",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_Genre", x => new { x.TrackId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_Track_Genre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Track_Genre_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_ApplicationUser_ApplicationUserId",
                table: "ArtistProfile_ApplicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_ApplicationUser_ArtistProfileId",
                table: "ArtistProfile_ApplicationUser",
                column: "ArtistProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_CreatedById",
                table: "ArtistProfile",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_LastModifiedById",
                table: "ArtistProfile",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_Track_ArtistProfileId",
                table: "ArtistProfile_Track",
                column: "ArtistProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_Track_TrackId",
                table: "ArtistProfile_Track",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Following_ApplicationUserId",
                table: "Following",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Following_ArtistProfileId",
                table: "Following",
                column: "ArtistProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_ArtistId",
                table: "Track",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_CreatedById",
                table: "Track",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Track_LastModifiedById",
                table: "Track",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Genre_GenreId",
                table: "Track_Genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Genre_TrackId",
                table: "Track_Genre",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistProfile_ApplicationUser");

            migrationBuilder.DropTable(
                name: "ArtistProfile_Track");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.DropTable(
                name: "Track_Genre");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "ArtistProfile");
        }
    }
}
