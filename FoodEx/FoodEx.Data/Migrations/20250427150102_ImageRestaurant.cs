using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Data.Migrations
{
    public partial class ImageRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImmageURL",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1,
                column: "ImmageURL",
                value: "https://www.google.com/imgres?q=restaurant&imgurl=https%3A%2F%2Fariabgrestaurant.com%2Fuf%2Fgallery%2F2846172000%2Fl_dsc06678.jpg&imgrefurl=https%3A%2F%2Fariabgrestaurant.com%2F&docid=MtPFkaVDaWY6ZM&tbnid=unNF9LmsDUBKaM&vet=12ahUKEwjLyeuMvfiMAxW0QvEDHYdqE9kQM3oECGYQAA..i&w=1067&h=600&hcb=2&ved=2ahUKEwjLyeuMvfiMAxW0QvEDHYdqE9kQM3oECGYQAA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImmageURL",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d015e9f4-a0d7-4649-9de3-44858ed5660b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fd779c85-7335-41a9-be6e-089b25d8dfd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c7333c78-3eed-41b2-9d3e-e0fd3d0bff9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "0c441d26-11f5-447b-aa4f-8e690cea2907");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be9e5892-d815-4a55-8261-ff16fb30f45c", "AQAAAAEAACcQAAAAEDvu9iG3MmFjjcBnrWIcXG9I4pgF+Oopp8VzGopn2iVTBopeSdgPlUkUhJDx109NHg==", "00e19e65-0cdb-41ca-993c-4da4c2e83738" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2635668-1c81-4b58-b692-459e46cfaee0", "AQAAAAEAACcQAAAAEEkNmrbu34ZjagEaitXn7BUp1mUS+6K1pdnLLW4r8vqw8UaCXNqhujNpTE9BRmcNug==", "8296c983-ae6a-4af2-9594-b90c3b1664e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f38dee3-df99-485d-8673-c9d3f4a58123", "AQAAAAEAACcQAAAAEOzC32TRGix1X/plzGc86qMBFX/nZe8kfC0/nS/6ZBDeSAK1pm8g2opyzfSL2UzIrA==", "795e6be1-d5f4-424e-a235-9a28579a8dd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe9e5e34-4619-4b2e-ae7c-1db28c8b9aee", "AQAAAAEAACcQAAAAEJrMIE5z8Cj8yiucyhurYWqNTWjuv9MMjvTjtA/f6biduIkDlAkYatxtlo2od6ljxQ==", "ace0dd3b-ee3a-4505-a09d-505b3dbc15cb" });
        }
    }
}
