using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class FeatureAddedUniqueUserEmailConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4723), new DateTime(2022, 12, 28, 17, 52, 10, 498, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 59, 38, 339, DateTimeKind.Utc).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 27, 16, 59, 38, 339, DateTimeKind.Utc).AddTicks(920), new DateTime(2022, 12, 27, 17, 0, 38, 339, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 59, 38, 339, DateTimeKind.Utc).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 59, 38, 339, DateTimeKind.Utc).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 27, 16, 59, 38, 339, DateTimeKind.Utc).AddTicks(898));
        }
    }
}
