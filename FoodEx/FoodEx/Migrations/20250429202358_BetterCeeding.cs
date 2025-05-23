﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodEx.Migrations
{
    public partial class BetterCeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_AspNetUsers_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeliveryGuyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PayMethod = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_DeliveryGuyId",
                        column: x => x.DeliveryGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_UserFavorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "0065ae10-afae-44dd-9ca0-eeac73d08037", "Admin", "ADMIN" },
                    { "2", "46f761dc-e9df-49aa-bd53-7ee0a6ff64b3", "User", "USER" },
                    { "3", "84f72335-39be-4fda-aa99-ae3d3aa621f0", "DeliveryGuy", "DELIVERYGUY" },
                    { "4", "5ed12ac5-39cb-43e4-92ce-1f52541253b8", "Restaurant", "RESTAURANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RestaurantId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-user-id", 0, "d1ba0169-8b9f-4773-aa33-83ae832e1f6a", "admin@foodex.com", true, false, null, "ADMIN@FOODEX.COM", "ADMIN", "AQAAAAEAACcQAAAAENBnmOWHFhjHxKv8fDiT612kO1j0UdTitwW/TaK19ocqukeAG+2GP/PQtgBt1IWjyA==", null, false, null, "3bf4e744-9fae-4d2b-9761-39bb1f5252f9", false, "admin" },
                    { "deliveryguy-user-id", 0, "4d5eacd2-a6f9-47df-a6e5-ac29ea0b32f1", "deliveryguy@foodex.com", true, false, null, "DELIVERYGUY@FOODEX.COM", "DELIVERYGUY", "AQAAAAEAACcQAAAAEO92/QdQ3pt4gqkxm9GlTiygk9JIfQ/ruSAMX3cOO7qMMFn8ePkJ4ACyAfoBrbE5bQ==", null, false, null, "0c186246-3503-4ca9-8e02-f349f762ee72", false, "deliveryguy" },
                    { "regular-user-id", 0, "8c3f3589-69e3-4252-9f44-3ef08fe8d524", "user@foodex.com", true, false, null, "USER@FOODEX.COM", "USER", "AQAAAAEAACcQAAAAEJNT3v6Z/uQPEzjQnFnu5SvudVmBACTQUi+AiSDq2CL244QUYLVZ7Wog16SxlO7Gtw==", null, false, null, "06cab0eb-7d64-4c2f-80dd-c7426389b272", false, "user" },
                    { "restaurant-owner-2", 0, "30066314-1acc-4e99-aa6f-5fcc827ae491", "pizzalover@foodex.com", true, false, null, "PIZZALOVER@FOODEX.COM", "PIZZALOVER", "AQAAAAEAACcQAAAAENGkF/RjMIEAuBL7ysgxlArRDs7HyBv/I4NC2nrjkplim55DKCA7Y8HpW40wrgwQgQ==", null, false, null, "f06d2561-412f-458b-9715-3a2ac66297eb", false, "pizzalover" },
                    { "restaurant-owner-3", 0, "4f5736fb-89fc-496d-8583-85b120be25fa", "burgerboss@foodex.com", true, false, null, "BURGERBOSS@FOODEX.COM", "BURGERBOSS", "AQAAAAEAACcQAAAAECj7YrdMxw8IY+rAPLDN7yiV3YW+R6OzMCaz+EBXoU4DbTiWCn6PlADOExTwWV4ZJA==", null, false, null, "5942a49c-e9e1-4f7e-ba12-0950de08aa62", false, "burgerboss" },
                    { "restaurant-user-id", 0, "a4b7d13a-4a39-46de-8f27-47bfa3f7ead2", "restaurantowner@foodex.com", true, false, null, "RESTAURANTOWNER@FOODEX.COM", "RESTAURANTOWNER", "AQAAAAEAACcQAAAAEBb4eYdhgxAEWw3b8vIEMjOFhaJOqRG1NfrIW3l4zGiiGTP6OShT/yBukBBdfVZNvA==", null, false, null, "ca807b99-5ad4-43d2-af65-45b4440e4210", false, "restaurantowner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "admin-user-id" },
                    { "3", "deliveryguy-user-id" },
                    { "2", "regular-user-id" },
                    { "4", "restaurant-user-id" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "ImageURL", "Location", "Name", "OwnerUserId", "Phone" },
                values: new object[,]
                {
                    { 1, "data:image/jpeg;base64,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", "123 Main St, Food City", "Gourmet Paradise", "restaurant-user-id", "555-1234" },
                    { 2, "https://www.google.com/imgres?q=rastaurant&imgurl=https%3A%2F%2Ftoohotel.com%2Fwp-content%2Fuploads%2F2022%2F09%2FTOO_restaurant_Panoramique_vue_Paris_nuit_v2-scaled.jpg&imgrefurl=https%3A%2F%2Ftoohotel.com%2Fen%2Ftoo-restaurant-en%2F&docid=DUqTn5OiOG00GM&tbnid=9NgHjxUjWdi-rM&vet=12ahUKEwilnvaYh_6MAxWFRvEDHSzQF_oQM3oFCIgBEAA..i&w=2560&h=1707&hcb=2&ved=2ahUKEwilnvaYh_6MAxWFRvEDHSzQF_oQM3oFCIgBEAA", "456 Pizza Lane, Food City", "Pizzeria Bella", "restaurant-owner-2", "555-5678" },
                    { 3, "https://www.google.com/imgres?q=rastaurant&imgurl=https%3A%2F%2Fwww.restolacuisine.com%2Frestaurants%2Frestaurant-la-cuisine%2Fwebsite%2Fimages%2FLacuisine_resto.jpg&imgrefurl=https%3A%2F%2Fwww.restolacuisine.com%2Fen%2F&docid=7cTafdiNks18-M&tbnid=ZdwoWxXSaZEwxM&vet=12ahUKEwilnvaYh_6MAxWFRvEDHSzQF_oQM3oECFwQAA..i&w=864&h=576&hcb=2&ved=2ahUKEwilnvaYh_6MAxWFRvEDHSzQF_oQM3oECFwQAA", "789 Burger Blvd, Food City", "Burger House", "restaurant-owner-3", "555-9876" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Category", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Pizza", "Classic margherita pizza with fresh basil and mozzarella.", "data:image/webp;base64,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", "Margherita Pizza", 8.99m, 1 },
                    { 2, "Pasta", "Spaghetti with traditional bolognese sauce.", "data:image/webp;base64,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", "Spaghetti Bolognese", 10.99m, 1 },
                    { 3, "Dessert", "Delicious coffee-flavored Italian dessert.", "data:image/webp;base64,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", "Tiramisu", 5.99m, 1 },
                    { 4, "Pizza", "Spicy pepperoni with melted cheese.", "https://www.google.com/imgres?q=pepperoni%20pizza&imgurl=https%3A%2F%2Fwww.hunts.com%2Fsites%2Fg%2Ffiles%2Fqyyrlu211%2Ffiles%2FuploadedImages%2Fimg_6934_48664.jpg&imgrefurl=https%3A%2F%2Fwww.hunts.com%2Frecipes%2Fquick-easy-meals%2Feasy-pepperoni-pizza-6934&docid=UinU8SS3nbI-3M&tbnid=vHZe8z-25XU5RM&vet=12ahUKEwjZo5nNhv6MAxUJQ_EDHTnHAHMQM3oECFIQAA..i&w=1000&h=1000&hcb=2&ved=2ahUKEwjZo5nNhv6MAxUJQ_EDHTnHAHMQM3oECFIQAA", "Pepperoni Pizza", 9.99m, 2 },
                    { 5, "Pizza", "Blend of mozzarella, cheddar, gorgonzola, and parmesan.", "https://www.google.com/imgres?q=cheese%20pizza&imgurl=https%3A%2F%2Fwww.foodandwine.com%2Fthmb%2FWd4lBRZz3X_8qBr69UOu2m7I2iw%3D%2F1500x0%2Ffilters%3Ano_upscale()%3Amax_bytes(150000)%3Astrip_icc()%2Fclassic-cheese-pizza-FT-RECIPE0422-31a2c938fc2546c9a07b7011658cfd05.jpg&imgrefurl=https%3A%2F%2Fwww.foodandwine.com%2Fclassic-cheese-pizza-6421445&docid=S5cBNkFjU2dZpM&tbnid=ZiJze8NWYgm1BM&vet=12ahUKEwjzrvLfhv6MAxVTSvEDHTxsNCgQM3oECB4QAA..i&w=1500&h=1000&hcb=2&ved=2ahUKEwjzrvLfhv6MAxVTSvEDHTxsNCgQM3oECB4QAA", "Four Cheese Pizza", 11.50m, 2 },
                    { 6, "Burger", "Juicy beef patty with cheddar, lettuce, and tomato.", "https://www.google.com/imgres?q=cheeseburger&imgurl=https%3A%2F%2Fi.ytimg.com%2Fvi%2FSvOx7tA_Cv8%2Fmaxresdefault.jpg&imgrefurl=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DSvOx7tA_Cv8&docid=sa9jOBTRimxNKM&tbnid=tpaWsx-k-6zFLM&vet=12ahUKEwjBzvHrhv6MAxUURvEDHffnOtwQM3oFCIQBEAA..i&w=1280&h=720&hcb=2&itg=1&ved=2ahUKEwjBzvHrhv6MAxUURvEDHffnOtwQM3oFCIQBEAA", "Classic Cheeseburger", 7.99m, 3 },
                    { 7, "Burger", "Two beef patties with crispy bacon and extra cheese.", "https://www.google.com/imgres?q=bacon%20Burger&imgurl=https%3A%2F%2Fwww.fullerssugarhouse.com%2Fwp-content%2Fuploads%2F2021%2F08%2Fmaplebaconburger.jpg&imgrefurl=https%3A%2F%2Fwww.fullerssugarhouse.com%2Frecipes%2Fmaple-bacon-burger%2F&docid=xnwFz_qwHBAkEM&tbnid=7un67IesMv2gVM&vet=12ahUKEwiUu9H3hv6MAxVGQvEDHYa8H7cQM3oECBYQAA..i&w=2508&h=1672&hcb=2&ved=2ahUKEwiUu9H3hv6MAxVGQvEDHYa8H7cQM3oECBYQAA", "Bacon Double Cheeseburger", 10.99m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FoodId",
                table: "CartItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodId",
                table: "OrderItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryGuyId",
                table: "Orders",
                column: "DeliveryGuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FoodId",
                table: "Ratings",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerUserId",
                table: "Restaurants",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_RestaurantId",
                table: "UserFavorites",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restaurants_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_OwnerUserId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
