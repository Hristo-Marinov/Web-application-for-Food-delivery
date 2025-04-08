using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class DecimalFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "921f692e-6c08-49ee-954a-2d1447a2222d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "eaed651c-aa2c-48f4-9482-c65138504098");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "6e0fd75b-71df-48ce-90eb-c1fbe8100043");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "061adf55-c931-47f3-a6e8-8508882383d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48256583-f6c9-4806-81e6-36b24d79643e", "AQAAAAEAACcQAAAAEJ1i4n4OVbVkOYqDApEY+s6BQMOpMrwFC6tfMLfMjgRt1ZoUEXMTV/uE2rTkTo06Gw==", "2f61adbb-b987-4b9a-9273-500559f6e689" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ef1cbbe-7d26-4c29-bcf1-cc9e3b943ac4", "AQAAAAEAACcQAAAAED2oJjVIk1qGGU9oxnGvfdpZvQzVOLKksn4Fl4ZyRq6xXh6GDDd5t1z6WBCBvTL/bw==", "a0e4ed2c-0fc2-4ef9-bc49-3a0fa31bee07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf0d4ac6-a26f-4922-bb04-064e3f3fa9fd", "AQAAAAEAACcQAAAAEKdrSj1X3BS6LL7/yIMVd3cLmmX1QH11cVjjpr8jt9nLsVSWiol3ONJxluqSaqbWtg==", "27a1382a-40cd-4a5b-bf75-2b9e3cc69214" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e522e7a3-6323-480d-b69c-f00f7fbb3b0e", "AQAAAAEAACcQAAAAEKR6KOACg0dHJKP7OtmJv+TC7MlTPssTg22OPEDgrqYUc0EG8Y8jhNVQGlchaFcbyQ==", "ff599bb2-05d7-4107-925f-04d1c4b37a6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4571f3bf-bb8a-49d1-b29b-4099b4987cde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7cb984ff-04cc-42f7-9b75-b942169450ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ce7b3d81-995c-4bec-963c-a7070c830748");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "dbe790d6-4dc4-4456-bf85-4366f83f8a4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4253af1e-c064-4b45-9f3a-747a0ae2b153", "AQAAAAEAACcQAAAAELUz/sTLdJ0PYlTF8t+0P1sqWOHnZCp/WRlXeyuXaDBByiMEKJnObO5v9OJOdYTicw==", "a602e02c-673e-4275-a4f0-d0939242b5a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b5829bb-67cd-4256-9442-5cb37a9cb7ac", "AQAAAAEAACcQAAAAEPkn31t+NQ4SpYUGUWDz65tw8c0A27j0PpgJ6qrbiWOl/vkRypFSUr+OXzeXwuyY6Q==", "eedba701-0cd7-4b11-86ea-236eddbbe93c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64397ae8-d83a-4999-a056-271c9d79052e", "AQAAAAEAACcQAAAAELlLCPlvutFyapBKRSjryNSJpcFs3KPsHP7IcT3JvuqpY2dADo/rSWnPBkeyolR3rQ==", "56d75622-668a-42f1-a44f-6df9ef68df27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a22fbfa5-3dbd-4843-a882-20b5373a2187", "AQAAAAEAACcQAAAAEFJL1q/akIAHybLP9MmvhVt0vHD8voVLsxDcB/OiiYkNJJJSrNZ56sZHk2+22IyPGA==", "09571a30-f8ff-4348-8d39-dbb7dde41797" });
        }
    }
}
