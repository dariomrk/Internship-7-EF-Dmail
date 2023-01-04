using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class FeatureAddedHiddenFromSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HiddenFromSender",
                table: "Mails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiddenFromSender",
                table: "Mails");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 29, 16, 56, 53, 155, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 29, 16, 56, 53, 155, DateTimeKind.Utc).AddTicks(4302), new DateTime(2022, 12, 29, 16, 57, 53, 155, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 29, 16, 56, 53, 155, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 29, 16, 56, 53, 155, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 29, 16, 56, 53, 155, DateTimeKind.Utc).AddTicks(4282));
        }
    }
}
