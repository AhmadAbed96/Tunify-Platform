using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addSeedDataForPlayListSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playListSongs",
                columns: new[] { "PlaylistId", "SongsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playListSongs",
                keyColumns: new[] { "PlaylistId", "SongsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "playListSongs",
                keyColumns: new[] { "PlaylistId", "SongsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "playListSongs",
                keyColumns: new[] { "PlaylistId", "SongsId" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
