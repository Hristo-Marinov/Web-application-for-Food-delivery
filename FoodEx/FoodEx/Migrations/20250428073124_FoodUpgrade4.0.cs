using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class FoodUpgrade40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "10c172ee-a50a-4df4-8a0b-788e0c50aca3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9398450d-9dd5-4570-9bf7-9e4f18efc3b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "1bc9a22f-b49b-46c3-abb6-367316aad57d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "6e454bb4-d553-4541-bbe1-86c3d9a83e11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23378da5-c284-47d8-8594-c2bee5e2822e", "AQAAAAEAACcQAAAAEIBmj937rc/s5+48utROVJ2j//H9y9mGFXKZ0bO5EHZzp2RXXlproZ1DI3Ku/ZFK7A==", "c5f6848c-5bd0-4b72-a833-040c61adcfd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dd5998d-dc97-4ee5-b4cf-a06d17b29a9c", "AQAAAAEAACcQAAAAENRzEPLlWp6lyyfXxl3zm8NM79WZxZPtXiCJ3sd/6eC3EJAXhzF+bJ3mzV0CVbOaBA==", "490af9d3-cde5-4329-ae5a-7fc847257d1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05fb6452-34a8-4e8a-a9bd-90e589547ed3", "AQAAAAEAACcQAAAAEC3NyzLDj8mn+8qLDToMRLG5jyRm24W4yP7YQuZ5QsjGQR8yR38yAac/ZvClWB82yQ==", "9c4be7fd-cdd0-4d5a-a6c9-83ba5ef473cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1306797-af26-4740-872a-893ed60d47fd", "AQAAAAEAACcQAAAAEG/uExs1mCWiTzTWpDDMfgF+fU0r+3fbKY9hXgK9AUpnOB8lXs3hIjHNsBBeMDxgFg==", "981037d5-a61b-4e48-ace5-be62cb12a84d" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Classic pizza with tomato, mozzarella, and basil.", 1 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Spaghetti with pancetta, egg, and parmesan cheese.", 1 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Fresh romaine with Caesar dressing and croutons.", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "960b4b86-59b4-4975-bdf5-d9f7de3cfe03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4131c189-cb45-46b3-bfd5-0f5d7dac57b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f1174315-9192-4b85-98ed-11825f769ed0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "24900b20-f792-4aeb-b409-8db08875eb03");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a4c3b0-73d6-45e1-8f86-1c10a29b51cf", "AQAAAAEAACcQAAAAEDS5huGcnzS8cFHjJcTK3CK1zc31VPkSfAlL2PDhVh16Y7aQ8ddJ9xJj45CQR4yqYA==", "8a8b6a3f-22fe-4466-a787-2946345570d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03cf647c-8f6e-4654-b855-2b5ddd5b3732", "AQAAAAEAACcQAAAAEMbOZRio5usqk5O0lgKFb6VGH3r6HUlem7u55s+OqqtJ8vPt84+Wvf7AgcVrdD2Hpw==", "163b0904-f517-49c3-b76d-d1bab4510ec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d58ad501-a33a-46fb-bb3b-6306c22e2c10", "AQAAAAEAACcQAAAAECyM9T3ZRRdamFzZh+duu4BJ1vX85B/s+o99DYLKZhF2f/pl9pAlFgDR/NGr1ybScg==", "defe9e7c-3690-4763-96f0-916333efd524" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f569a7f-b7c0-4179-8d46-d961cee691cb", "AQAAAAEAACcQAAAAEJ2G4GzsMyqzutJymOyqoA2MZbWFDSkmY2mjuYUxkVr0aacLCxPDH0qLHV1EbBz5iw==", "6abeb58c-c84c-4905-b639-df93413315e5" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Classic pizza with tomato sauce and mozzarella.", 0 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Spaghetti pasta with pancetta, eggs, and parmesan.", 0 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                columns: new[] { "Description", "RestaurantId" },
                values: new object[] { "Fresh romaine lettuce with Caesar dressing and croutons.", 0 });
        }
    }
}
