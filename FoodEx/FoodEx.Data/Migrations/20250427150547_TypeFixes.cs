using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Data.Migrations
{
    public partial class TypeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImmageURL",
                table: "Restaurants",
                newName: "ImageURL");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7f5bf9c5-0d21-407a-9c30-2da31e5f30a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a5e314c2-582f-493c-8d7f-5e42fca6c75f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c9d1b998-b534-48a1-baf2-df9899741278");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "1d0940d7-2352-48ff-9c03-e628a9888956");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe30a785-7617-46a8-8283-546997dd1682", "AQAAAAEAACcQAAAAEKm+wtuMlipHbItgQE8O8NL3A7DgGGg70Q06fXI94GFITO11nrTbBJFTDE7bCIoQGg==", "a34569ba-6363-403d-911b-282308a8626d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a085c339-2340-4958-8ef2-603fdf32521b", "AQAAAAEAACcQAAAAEJyJOMKOcjM0KzVHholI6sIrAOO2mU2RRsRbjfaOwySzLZFwl7rstka6IshcUiwfkg==", "49912922-c5e6-4aa2-aac8-c908522623ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43dfac11-7c89-4fdc-a451-ba805c2641df", "AQAAAAEAACcQAAAAED+3gg2HweWqDB00ZdrjM1vIeS5XwuT/8eWK+QAEna46ZobiNBQFnDdIoWo0VCtQbQ==", "70b9b22f-b6ee-4ae1-b622-1f9dd2a84e18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "516058a5-da36-43be-8821-1a4dc97ba5d2", "AQAAAAEAACcQAAAAEDV/gn6Yp1pGJjCM4SoL8rUy+pQWmdASampOwXtur7xeljWGxl3u9gUVd7uCIdxaBA==", "aea3fd58-88d6-45f0-b042-39afcc252a11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Restaurants",
                newName: "ImmageURL");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "28ee6513-c3b5-4ccd-90da-101c16677251");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "11bd6096-955e-459e-a4fe-c704c46a219d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a464d7ef-058a-4221-ac88-16d271b2dec7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "99167e6c-9bb9-4591-b4d4-0896724540fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1bd859c-1b3e-4008-9a67-9a1094f23818", "AQAAAAEAACcQAAAAEJkOaiMjtxVfkmwl2Bvjehyea+hv1HrzpkpOs///fXvD7qO0IC9FRKUBjvLpLgKtpA==", "d901f701-5d87-4341-95ab-1d1a98fa47e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe2cfc75-f15a-45cb-a57b-7c0d47482e07", "AQAAAAEAACcQAAAAEDX0YVCrTMubsH1Qc9B1IK7LfSXNryw/wjKIubAk4mfpDPrZcbq5epGQ3CtMgoPzXA==", "b053d0c2-c3e3-401f-9304-d8f2c53d1908" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c08f5a21-b2aa-4d7d-889c-67ede72acb5b", "AQAAAAEAACcQAAAAEPrXDja8mG6APRF/vOTHfJvYiJzR8CyhZUZtNxra/PZRUqkGLKPhYBmroDHv3wTvXw==", "0ac5b04e-fecb-497e-b45d-4e937979143f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c6b8ea-7ba4-48e3-882b-3665c779e53d", "AQAAAAEAACcQAAAAEAH2XP7BSYLIwyXemitLPFiHoUUHIs1uX3lLvmRa5BfEb+ONRLd3lSvAZMI3wbN56w==", "628fb33c-96fb-4b2f-8406-9b2dc521eb08" });
        }
    }
}
