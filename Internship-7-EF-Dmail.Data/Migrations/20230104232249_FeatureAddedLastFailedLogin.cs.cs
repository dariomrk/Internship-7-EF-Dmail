using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class FeatureAddedLastFailedLogincs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastFailedLogin",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastFailedLogin",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 22, 33, 57, 436, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2023, 1, 4, 22, 33, 57, 436, DateTimeKind.Utc).AddTicks(4040), new DateTime(2023, 1, 4, 22, 34, 57, 436, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 22, 33, 57, 436, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 22, 33, 57, 436, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 4, 22, 33, 57, 436, DateTimeKind.Utc).AddTicks(4021));
        }
    }
}
