using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class RemoveNullableOnRecipientMailStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MailStatus",
                table: "Recipients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

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
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1110), new DateTime(2023, 1, 6, 22, 58, 55, 356, DateTimeKind.Utc).AddTicks(1110) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MailStatus",
                table: "Recipients",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

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
    }
}
