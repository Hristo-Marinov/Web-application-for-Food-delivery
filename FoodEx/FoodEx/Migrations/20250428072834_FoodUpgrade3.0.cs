using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class FoodUpgrade30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Classic pizza with tomato sauce and mozzarella.", "https://via.placeholder.com/300x200.webp", "Pizza Margherita", 9.99m, 0 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Spaghetti pasta with pancetta, eggs, and parmesan.", "https://via.placeholder.com/300x200.webp", "Spaghetti Carbonara", 11.99m, 0 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Salad", "Fresh romaine lettuce with Caesar dressing and croutons.", "https://via.placeholder.com/300x200.webp", "Caesar Salad", 7.49m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dd409326-0cff-4747-9795-8738df69912d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "16313a68-c15b-4d5a-ae23-402f4d97caeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "bbaa73aa-6715-4680-85e6-103be58043b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "76445143-9422-4b03-9a81-bd8e5f0ff7ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc47bafe-4e6f-445c-b184-7d2ecb16288e", "AQAAAAEAACcQAAAAEE0yn8kMO4mk18FFQSujc4DRrpz941SlW8GV7gZqTVaH/PhS7QZfcP9sHVQ6ps1xuA==", "b314f767-221f-4d4f-b42c-2cbbb9045461" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f3a36fe-d147-44da-aa5d-a7dd0942f9e8", "AQAAAAEAACcQAAAAEOBCyDFDPrlROpUfz/tWYIu6fEtPPO14FcXnP14VgKHEUv1UG771RuX8AVSsdOERdg==", "3dae2a80-26dc-4650-b19c-96478a0a0c04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c660583-2f87-4d8a-98b1-6da99abae1e2", "AQAAAAEAACcQAAAAEGGzlAuzf4xAGVpLc3YynFbnoxu7YWa2GOq9REJKp9w+2wSxCFqVUuCD5nN83PWntA==", "e6f7497c-7a0f-48cb-ba08-f30681fef1b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dddb3d34-021b-4a1c-9013-54794c5277f9", "AQAAAAEAACcQAAAAEEdFc7sfRMM2EgbOrS3HROdUGg380xQy77xKb7/Tx8cQKkYkc5EGvR7GfMJ6y4qb3w==", "a9b5f4ad-db85-47a7-818d-777132b70592" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Classic margherita pizza with fresh basil and mozzarella.", "your base64 string here or url", "Margherita Pizza", 8.99m, 1 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Spaghetti with traditional bolognese sauce.", "your base64 string here or url", "Spaghetti Bolognese", 10.99m, 1 });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[] { "Dessert", "Delicious coffee-flavored Italian dessert.", "your base64 string here or url", "Tiramisu", 5.99m, 1 });
        }
    }
}
