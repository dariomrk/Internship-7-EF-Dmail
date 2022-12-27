using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Rights", "Status" },
                values: new object[] { 1, new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6133), "administrator@dmail.hr", "6372EA190AC157A4AFE6BD34B6D107A5B502785396C7A9C2A2FAC9E76DC5F676_87CA606D69D409AC3422D3ED1561ABD2_10000_SHA256", 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Status" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6138), "user@dmail.hr", "FD570FB17E4042EEA75E9F9DC05C1E7B13807BFB5C156BA5C9181C49D8DC39D8_2EAF520C6EF88385B9B1BEB7E9D9170C_10000_SHA256", 1 },
                    { 3, new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6139), "dario@dmail.hr", "9AE1940F019AB31BA6BFD29F59EA05EBAEC5DBBE99DE041FB65A6354AC2A110B_0B5843ABC5E5C10F493916C0790CC01A_10000_SHA256", 1 }
                });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "Id", "Content", "CreatedAt", "EventDuration", "EventStartAt", "Format", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6159), null, null, 0, 1, "First sample mail" },
                    { 2, null, new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6162), new TimeSpan(0, 0, 1, 0, 0), new DateTime(2022, 12, 27, 16, 41, 57, 504, DateTimeKind.Utc).AddTicks(6162), 1, 2, "Testing DMail" }
                });

            migrationBuilder.InsertData(
                table: "SpamFlags",
                columns: new[] { "FlaggedUserId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "MailId", "UserId", "EventStatus" },
                values: new object[,]
                {
                    { 1, 2, null },
                    { 1, 3, null },
                    { 2, 1, null },
                    { 2, 3, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SpamFlags",
                keyColumns: new[] { "FlaggedUserId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SpamFlags",
                keyColumns: new[] { "FlaggedUserId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "SpamFlags",
                keyColumns: new[] { "FlaggedUserId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
