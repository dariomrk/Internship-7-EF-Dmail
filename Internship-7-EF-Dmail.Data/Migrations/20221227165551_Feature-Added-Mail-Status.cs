using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class FeatureAddedMailStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MailStatus",
                table: "Recipients",
                type: "integer",
                nullable: true,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailStatus",
                table: "Recipients");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6162), new DateTime(2022, 12, 27, 16, 41, 57, 504, DateTimeKind.Utc).AddTicks(6162) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 40, 57, 504, DateTimeKind.Utc).AddTicks(6139));
        }
    }
}
