using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class FoodUpgrade50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b499ea1c-cdc9-41fb-aa60-9044926f0fb2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "22e7686a-4503-4f9c-8e26-2b11ade29600");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "fa9d56fb-fa18-4dc7-8d6a-ea869dcfc0af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "8aa41358-d0f8-45f6-a0a7-007f41db57ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffd69037-b199-4c00-9c2f-4120937bfa3b", "AQAAAAEAACcQAAAAEIoejI3kWvHELsU3x0R89TIKVHA2AlMIgK4NVScbbGbSZV6KwxkXu0UdC/UrioKKRQ==", "cbe1bfac-19aa-4a77-aad4-e893f87bb657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee3c17b7-d408-41fa-be25-97eb596317a3", "AQAAAAEAACcQAAAAEOt+7iJGUrIXsaPanYDQjPF9YqodGLhPdra4gw8zhxrJjETFBZXE3yNR1nBvQ9BRFQ==", "8eb460ee-06d9-4ca8-bcc7-08bb1bffcbd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74fadaaf-49b8-4821-81e3-1d5bacb46ce4", "AQAAAAEAACcQAAAAEEYqwB0l5MkXeWxWg0ZrowP2iF41skrLNr2GpirMhyDhM0gKo47LkNyhg6sMXu8O/A==", "f7835035-b69f-4375-aac9-0d397beefc2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80872e5f-e3ca-49a4-9ecf-50cbc3765eff", "AQAAAAEAACcQAAAAEOpNFrM6dWNteNgdd/xtveq8+1rJdIBvPb6wfGBNHzsr1OdgXSinbotRI5r2aodJ0Q==", "2c4b5f83-908a-4856-b67a-13333978f48d" });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "RestaurantId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 3,
                column: "RestaurantId",
                value: 2);
        }
    }
}
