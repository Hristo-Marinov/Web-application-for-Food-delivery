using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4f875268-7636-4880-9bce-32c242b66ac8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e75e47af-7acd-4d63-9b9a-01ef81286dcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "088431aa-c3f3-42f1-9ae8-78c62deaffdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "74ac91eb-ecaa-472a-a1b9-23d0d22aa4fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8b9459b-6e9e-46db-b93d-e63b42b008c1", "AQAAAAEAACcQAAAAENYv6zL0y/Y6is+sg0ehci7t34+eLzUogw0orwPJ1XK89yt45SThwbTkazpFAa+uTw==", "4e640418-ffbf-4e97-a11d-6d536b3e1ed8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ab8353-6ba9-4df1-8875-fec2cb0f230b", "AQAAAAEAACcQAAAAEDJ9u+/kIWKcw9iKoEp+Z1h6b2ahBCkhnH52TRTwOH2PZoA8bWu8nnkRT+KEjX+yyw==", "06b40779-b561-49ce-93b0-681af83b1429" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71041058-f2b7-4837-8c0c-1ffdf017fc33", "AQAAAAEAACcQAAAAEGj8itXk5/u6C6yaj2fFGQvf43heu/BYMMNFQSpiaJFOChZkv9myEkbwTM9cA9NoGQ==", "c8a30f00-a7f4-4c65-b0ed-ca885e89c548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9c0020f-6737-473d-b1e7-d88e3f778b04", "AQAAAAEAACcQAAAAEAu2bWXMEcRmt8FKQyktsYlrcUHE8e5sKveVEUex+//X7/MNX5L49Gx0Ge5HIZ9rIw==", "a9a91192-7923-4ef2-9d5d-0fa8aa87ab71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-owner-3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "030d63c3-ded8-4598-af21-ada8a69a80af", "AQAAAAEAACcQAAAAEET+VeP9nrrikMsIyQj7sOGdDVlNp4QOM6M4YD7i9Aoez2mLeXAtO8W0kX1A9irj+Q==", "913fa617-b677-43c6-9e40-e28f20002b7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9ae6312-5ec3-4808-b3ef-0d1e007fe9c2", "AQAAAAEAACcQAAAAEIRObvjcy9QjII3Es+tLO1iURBKgknU1P2hALZTGO5mCGePDhWNZKPrJtWmTzPzHPA==", "b4c8de9e-b178-4b3a-b5c3-263df457a687" });
        }
    }
}
