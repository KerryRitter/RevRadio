using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RevRadio.Migrations
{
    public partial class AddingExternalArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "ExternalArtist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalSourceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Popularity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalArtist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalArtist_Genre",
                columns: table => new
                {
                    ExternalArtistId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalArtist_Genre", x => new { x.ExternalArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ExternalArtist_Genre_ExternalArtist_ExternalArtistId",
                        column: x => x.ExternalArtistId,
                        principalTable: "ExternalArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExternalArtist_Genre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalArtistRelatedArtist",
                columns: table => new
                {
                    ExternalArtist1Id = table.Column<int>(nullable: false),
                    ExternalArtist2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalArtistRelatedArtist", x => new { x.ExternalArtist1Id, x.ExternalArtist2Id });
                    table.ForeignKey(
                        name: "FK_ExternalArtistRelatedArtist_ExternalArtist_ExternalArtist1Id",
                        column: x => x.ExternalArtist1Id,
                        principalTable: "ExternalArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalArtistRelatedArtist_ExternalArtist_ExternalArtist2Id",
                        column: x => x.ExternalArtist2Id,
                        principalTable: "ExternalArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "ExternalArtistId",
                table: "Tag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ExternalArtistId",
                table: "Tag",
                column: "ExternalArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalArtist_Genre_ExternalArtistId",
                table: "ExternalArtist_Genre",
                column: "ExternalArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalArtist_Genre_GenreId",
                table: "ExternalArtist_Genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalArtistRelatedArtist_ExternalArtist1Id",
                table: "ExternalArtistRelatedArtist",
                column: "ExternalArtist1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalArtistRelatedArtist_ExternalArtist2Id",
                table: "ExternalArtistRelatedArtist",
                column: "ExternalArtist2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_ExternalArtist_ExternalArtistId",
                table: "Tag",
                column: "ExternalArtistId",
                principalTable: "ExternalArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_ExternalArtist_ExternalArtistId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ExternalArtistId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ExternalArtistId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "ExternalArtist_Genre");

            migrationBuilder.DropTable(
                name: "ExternalArtistRelatedArtist");

            migrationBuilder.DropTable(
                name: "ExternalArtist");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tag",
                nullable: false,
                defaultValue: "");
        }
    }
}
