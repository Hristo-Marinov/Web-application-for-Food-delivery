using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class MasterFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "af2b0c10-56a1-4e83-8ab4-15f0abc41952");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9aeefff3-1ef8-4dee-a822-bb170c525660");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "32afeefa-3843-43dd-a097-c37975134a05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "fca2b98d-b8a8-49da-bc5c-e5a181a4f1fc");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4", "restaurant-owner-2" },
                    { "4", "restaurant-owner-3" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "266895af-1cfd-4f26-b2de-ebbf60f8c813", "AQAAAAEAACcQAAAAEPrI6Vb2Rp+eHh90wim2yuaVfGe18zZcd+bMJDGkadBd85ac1EIikMbmaEVv7atT0Q==", "f331e416-e514-4658-88ed-a01872700060" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faee63b8-65e8-44f6-88c3-0f18defb5285", "AQAAAAEAACcQAAAAEMiy6yvYKdnDWOOLF2gaUrEDXD1CVcXQbtqhJ9XGLkH7+CyD4uOm1CUWngtuAu8+zg==", "e5784217-1591-452c-9325-ddf3e1d76de3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3db4ca48-e8ee-4cb1-94f8-7ec283da787e", "AQAAAAEAACcQAAAAEFDObdIvwnkwV3PKAkGqXBRl/pshvsa6n/sq81J/5TXf2Vrf8La1iuiZTqmsJthGOA==", "258a84ac-001b-443e-8ab6-79eacd8b2c95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "727e0bbf-2274-47c9-aa13-640e963f2b7d", "AQAAAAEAACcQAAAAEGWUElzaVayDlbQBO/RjICcIo6yc9c6+YdVbjZjZPoUk1M3BndCzp1z12vnSXFUnUA==", "3105423b-de6b-4e9e-8b84-cb46e8b5efae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36ffd85c-a668-47c0-bb88-daea13b26ad4", "AQAAAAEAACcQAAAAEEoNW4UizhJtBVEFqIpb2O+OTD1jAJovk5IZedXJxWRd8H6uYITVccLHVyS0Vs0vBQ==", "9053d3be-55bd-46b2-b94c-7f7b878d3481" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3580b05a-a538-4918-bedf-95d88166bb0b", "AQAAAAEAACcQAAAAEFGjJV1c/PTPqXkU2XZEQP7P1TB2KathXjYyGKldfv+wG3pYv/nPW6ZyqJxASD2g/A==", "98361fca-d214-4d3f-870b-1886d7d4fc8e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "restaurant-owner-2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "restaurant-owner-3" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fecd5963-4219-456d-9c81-297462ddca92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0250927b-8049-4478-9b0b-c10d9be5d68f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "cba215af-14dd-45c0-a261-4c1f9195a8cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "29553a20-38bf-4066-8b8b-ee05ce99c8f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b22c3757-4ba5-4605-b629-c0b70fac089d", "AQAAAAEAACcQAAAAENKQIOx/RWGVNUwmrrpIZW3HIWeFnmnooc1M5789bFXnlOnHCxRi3919Jo7daioyNQ==", "0a9476ff-45c3-45f9-b55d-e9c66df4ba98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0edf17ea-a8de-44bf-880a-90180657f957", "AQAAAAEAACcQAAAAECuzYwnKJHABbcxpxFJL2Guw5nk5sCOero4VbSviJOMhYhzz0XedSD6whCOOALuklg==", "d56c5a2b-e5b0-4f39-a8c6-40db83e65d33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8293fa75-7fcc-4c0b-a963-085403e837e0", "AQAAAAEAACcQAAAAEFcLmma/p0w0fd1URqLg0+t9yvY8iZmRIKak+88CBLfF0eqjYuPBjs6I7qD215pGQg==", "a37fc27c-35fe-43eb-a9c3-6235e2bd9b65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3814559-7da6-4587-9c4f-c6e08492ea2d", "AQAAAAEAACcQAAAAEOEmEqleQMdRqZH+vRFC6xqlD4vZYB82A+Aa4rF0eddqL8pPW+jbNYAg7baxfz4bBw==", "32c40fb0-c8c9-41c9-817e-5a209caa8a18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9316c447-d4d9-4e1d-83a2-001fc1f96433", "AQAAAAEAACcQAAAAEACxRmUGGaFLpZsDOE1usOoaKRF0tigOyZ+AzGws8vWNkSVrZ4OBn8PHhshZF5AfBA==", "e54ce684-28fe-4e4a-9864-fc1f9c8aa3d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6721042b-b9d7-4a96-baa9-4056cb213209", "AQAAAAEAACcQAAAAEOCiBSsVWze4LMJwA6NABo/npBCDZ5wstfN6MuYr+Sx/pgU7MJvTVcvBPchqGZzBrg==", "f3d5197b-eb89-4182-93c4-f9d4dd292905" });
        }
    }
}
