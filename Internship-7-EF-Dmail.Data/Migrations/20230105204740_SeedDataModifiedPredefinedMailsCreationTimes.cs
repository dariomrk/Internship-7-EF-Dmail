using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class SeedDataModifiedPredefinedMailsCreationTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 5, 20, 47, 38, 878, DateTimeKind.Utc).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2023, 1, 5, 20, 47, 39, 878, DateTimeKind.Utc).AddTicks(2834), new DateTime(2023, 1, 5, 20, 48, 39, 878, DateTimeKind.Utc).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 5, 20, 47, 39, 878, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 5, 20, 47, 39, 878, DateTimeKind.Utc).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 5, 20, 47, 39, 878, DateTimeKind.Utc).AddTicks(2809));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 23, 22, 49, 336, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2023, 1, 4, 23, 22, 49, 336, DateTimeKind.Utc).AddTicks(616), new DateTime(2023, 1, 4, 23, 23, 49, 336, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 23, 22, 49, 336, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 23, 22, 49, 336, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 23, 22, 49, 336, DateTimeKind.Utc).AddTicks(597));
        }
    }
}
