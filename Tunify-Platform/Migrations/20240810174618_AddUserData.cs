using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Created_date",
                table: "playList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "artist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "album",
                columns: new[] { "AlbumId", "AlbumName", "ArtistId", "Release_Date" },
                values: new object[,]
                {
                    { 1, "Album 1", null, "20/4/2023" },
                    { 2, "Album 2", null, "21/4/2023" },
                    { 3, "Album 3", null, "20/4/2023" }
                });

            migrationBuilder.InsertData(
                table: "artist",
                columns: new[] { "ArtistId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, null, "Artist 1" },
                    { 2, null, "Artist 2" },
                    { 3, null, "Artist 3" }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "SubscriptionId", "Price", "Subscription_Type" },
                values: new object[,]
                {
                    { 1, 50m, "gold" },
                    { 2, 25m, "selver" },
                    { 3, 20m, "bronz" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UsersId", "Email", "Join_Date", "SubId", "UserName" },
                values: new object[,]
                {
                    { 1, "Abed@example.com", "20/4/2023", 1, "Abed" },
                    { 2, "Samer@example.com", "21/4/2023", 2, "Samer" },
                    { 3, "khaled@example.com", "20/4/2023", 3, "khaled" }
                });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 0, 0), "Pop", "Song 1" },
                    { 2, 2, 2, new TimeSpan(0, 0, 4, 0, 0), "Rock", "Song 2" },
                    { 3, 3, 3, new TimeSpan(0, 0, 5, 0, 0), "Jazz", "Song 3" }
                });

            migrationBuilder.InsertData(
                table: "playList",
                columns: new[] { "PlayListId", "Created_date", "PlayList_Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Playlist 1", 1 },
                    { 2, null, "Playlist 2", 2 },
                    { 3, null, "Playlist 3", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playList",
                keyColumn: "PlayListId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playList",
                keyColumn: "PlayListId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playList",
                keyColumn: "PlayListId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "album",
                keyColumn: "AlbumId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "artist",
                keyColumn: "ArtistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Created_date",
                table: "playList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
