using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class SeedDataAddedNewMails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 8, 22, 39, 4, 64, DateTimeKind.Utc).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 8, 23, 29, 4, 64, DateTimeKind.Utc).AddTicks(8197), new DateTime(2023, 1, 8, 23, 40, 4, 64, DateTimeKind.Utc).AddTicks(8197), "Testing DMail Events" });

            migrationBuilder.InsertData(
                table: "Mails",
                columns: new[] { "Id", "Content", "CreatedAt", "EventDuration", "EventStartAt", "Format", "SenderId", "Title" },
                values: new object[,]
                {
                    { 3, "Hello world from the admin.", new DateTime(2023, 1, 8, 23, 39, 3, 64, DateTimeKind.Utc).AddTicks(8205), null, null, 0, 1, "Hello there" },
                    { 4, "This one should arrive a bit later.", new DateTime(2023, 1, 8, 23, 39, 4, 64, DateTimeKind.Utc).AddTicks(8206), null, null, 0, 1, "Hello there again" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 8, 23, 39, 4, 64, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 8, 23, 39, 4, 64, DateTimeKind.Utc).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 8, 23, 39, 4, 64, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "MailId", "UserId", "EventStatus" },
                values: new object[,]
                {
                    { 3, 3, null },
                    { 4, 3, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 6, 22, 57, 54, 356, DateTimeKind.Utc).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1110), new DateTime(2023, 1, 6, 22, 58, 55, 356, DateTimeKind.Utc).AddTicks(1110), "Testing DMail" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1081));
        }
    }
}
