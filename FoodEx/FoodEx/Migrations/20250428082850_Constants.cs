using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class Constants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7c0ff502-bb99-40d0-a4ab-2ae791a34df0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6098e553-ce71-4e1a-9ed3-f51bb76b297a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f9490bbe-2837-40d8-a82b-eb4577ecc5e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "f55b9419-d533-43f5-bf79-6d1d3459492e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2ec5250-896c-4a67-9757-72d986953d7e", "AQAAAAEAACcQAAAAELL2csk7md5C8dObPhx03pSIzcsIOUQmkArJ/0/jgxy9AHDF+FXuF2zvj0uUaN60dw==", "bff075a6-a180-4b0e-bb5c-e6703cfcf740" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2fdbc6b-6f73-47bf-b544-d14ff7141f91", "AQAAAAEAACcQAAAAEMcCaagxuNqRBUkgzL6omfiRa3dpheEUaTtjvN7RCZj73hwXCCgVfntvcxNSE3IFUA==", "21cee879-876a-4576-a7a3-3ef0d8aabda6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be7a54d5-516c-4263-bd12-56f57b5bce13", "AQAAAAEAACcQAAAAECVNDvGgHF11EcwKyqoVB2i1oTTy9WYZ4ohfWGioJQ1mCCPGFixgfYA2GnilI7sqNw==", "b9ea283c-9944-40d9-9e11-1682257d113e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aa70832-c018-459d-9848-f8d21ec62bf7", "AQAAAAEAACcQAAAAEPJeph41fqQRtt2k1MTj/FPC7W39XzKkKJ4pomZ/VyzlOy0wLcI6OiT5Sr5szOEI5g==", "21b7d1eb-63ea-4e68-87cc-e0855b2c4c10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ae252abe-1037-4c03-b187-3e6386ca95fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1d177488-48f7-47e7-8a49-99247354dbce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a1d07bba-3ee7-42d4-9ca2-da468860e47a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "a74d95de-9921-4db9-a095-8d41b9a92a3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e4b7527-39bf-4de9-bbfc-d0630bbe3f51", "AQAAAAEAACcQAAAAEPALK3TLVq7kFwpkstOoK4d6j/Tlnea7NVLpu6ictPEfsvlT3kdbPHStd6C+xH6Ruw==", "1640d84d-61a2-49bd-8a4e-123cfd25505b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6913a5ee-003c-42be-9485-a0427b50a2fc", "AQAAAAEAACcQAAAAENYrj8Eo/18GDaYSt7MLI11H3rWedatbi2X9DvQG5rIqqKvAMMgU1CZZ01ZO5csFpw==", "4d272153-6170-4eff-8660-e936c1d97fb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f40808b-8460-4120-8202-1b4e2e45223b", "AQAAAAEAACcQAAAAEAqkZTtTfBIUeflVHIO2WC0ge5UOim6gj+pbl7JHKd0jdc88k2ZRV2iRiu6rnW3DLQ==", "404957e8-21ab-494d-be57-c2d72147e5ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fc8fbf4-de86-42dc-b0cf-5e2cf246fea8", "AQAAAAEAACcQAAAAEEPN5l17FyEQSoKJttmImHvh9rP9MnRFC0Vy17sJc4FpOeVYdjEGwtlgM2Ii/4APhA==", "0b954fd4-1f84-4cce-a7a5-4c7cbbef6786" });
        }
    }
}
