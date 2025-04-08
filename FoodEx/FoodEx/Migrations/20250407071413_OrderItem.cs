using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class OrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodId",
                table: "OrderItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1450de47-64d9-4c5d-a7c0-c7d6d8643035");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "75b74d08-19cb-44b8-b763-6938673800a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "50fe69ef-9930-498d-b8cf-286136b6010c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "7a20b20f-f426-46c0-801a-9726a6c2d40b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2eeeead3-3d38-44a6-b211-cc4fac773786", "AQAAAAEAACcQAAAAEE95yqp+hH6o8ciXwqsG7ekvn/7O7iLayChJN/Jo7jlzHldD0TqUetXjZukkwDilGg==", "9e33922d-3576-436e-afae-6320fcec679d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "deliveryguy-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d46883-4648-4ff6-83d5-4e5a95d28485", "AQAAAAEAACcQAAAAEN2xVIWTOMw3HgpNuCtX9RHey3ERh3G7ZGHLmLGGIHyBiiVNBgiyOaDynEw4fm5Fzg==", "ab5b5b81-c9c2-40f2-be4f-28dc5a1f2997" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "regular-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da6c5262-377b-4322-91f6-cd60d9b7f4d2", "AQAAAAEAACcQAAAAEBGJcjDkAODFXj2JdGxFyEkDdIDK3yKPeuDIRZjf5Sd0O9zykPcNNbN0Z3Pa+WwJLw==", "b8c07412-56be-4dd2-ab2a-9f0aa2f2de66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "restaurant-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a450f440-9edb-4b31-87f4-751d62c62cc0", "AQAAAAEAACcQAAAAEIaOBEZr0viAeW80aSJcLszG/VEuQCqCksdJrIuAzzlCXCoym/DTCx146+M1AB5uKg==", "dcd997d2-118f-4b9b-b1ab-cee708badb31" });
        }
    }
}
