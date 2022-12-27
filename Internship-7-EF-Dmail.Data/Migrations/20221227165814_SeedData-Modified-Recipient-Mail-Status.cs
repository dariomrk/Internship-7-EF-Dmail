using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class SeedDataModifiedRecipientMailStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 58, 13, 922, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 27, 16, 58, 13, 922, DateTimeKind.Utc).AddTicks(2238), new DateTime(2022, 12, 27, 16, 59, 13, 922, DateTimeKind.Utc).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "EventStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "EventStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 58, 13, 922, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 58, 13, 922, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 58, 13, 922, DateTimeKind.Utc).AddTicks(2214));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1780), new DateTime(2022, 12, 27, 16, 56, 50, 850, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "EventStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipients",
                keyColumns: new[] { "MailId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "EventStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1753));
        }
    }
}
