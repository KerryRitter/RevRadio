using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevRadio.Migrations
{
    public partial class AddingTagAndGenresToArtistAndTracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistProfile_Genre",
                columns: table => new
                {
                    ArtistProfileId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistProfile_Genre", x => new { x.ArtistProfileId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistProfile_Genre_ArtistProfile_ArtistProfileId",
                        column: x => x.ArtistProfileId,
                        principalTable: "ArtistProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtistProfile_Genre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Track_Tag",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_Tag", x => new { x.TrackId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Track_Tag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Track_Tag_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_Genre_ArtistProfileId",
                table: "ArtistProfile_Genre",
                column: "ArtistProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfile_Genre_GenreId",
                table: "ArtistProfile_Genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Tag_TagId",
                table: "Track_Tag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Tag_TrackId",
                table: "Track_Tag",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistProfile_Genre");

            migrationBuilder.DropTable(
                name: "Track_Tag");
        }
    }
}
