using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    public partial class SeedDataModifiedPasswordSHAIterations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 29, 10, 43, 46, 342, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "Mails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EventStartAt" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 43, 46, 342, DateTimeKind.Utc).AddTicks(915), new DateTime(2022, 12, 29, 10, 44, 46, 342, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 43, 46, 342, DateTimeKind.Utc).AddTicks(893), "5845B848BD99AA5475E670D8518D63D142575340C29CEFDF56F5EFEA28068310_CC18CC50FB84BF2EB9C806C10C469716_100000_SHA256" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 43, 46, 342, DateTimeKind.Utc).AddTicks(895), "CB228A47EACC6C7ABF8F8DA723679F8AB1E26295221090C89E0AFC3282F45519_1903295D3BE77E41AC3ABBE41A35459B_100000_SHA256" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 29, 10, 43, 46, 342, DateTimeKind.Utc).AddTicks(896), "8ECF23A945F94B746FBEC39022F694BC6DAE3D43C551F968F7407D140F79B8FE_9C3A3884E70F8CD724B094A75CEEAF20_100000_SHA256" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4701), "6372EA190AC157A4AFE6BD34B6D107A5B502785396C7A9C2A2FAC9E76DC5F676_87CA606D69D409AC3422D3ED1561ABD2_10000_SHA256" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4703), "FD570FB17E4042EEA75E9F9DC05C1E7B13807BFB5C156BA5C9181C49D8DC39D8_2EAF520C6EF88385B9B1BEB7E9D9170C_10000_SHA256" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2022, 12, 28, 17, 51, 10, 498, DateTimeKind.Utc).AddTicks(4704), "9AE1940F019AB31BA6BFD29F59EA05EBAEC5DBBE99DE041FB65A6354AC2A110B_0B5843ABC5E5C10F493916C0790CC01A_10000_SHA256" });
        }
    }
}
