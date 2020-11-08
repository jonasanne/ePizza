using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.Models.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    RestaurantName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    PizzaType = table.Column<int>(nullable: false),
                    OrderType = table.Column<int>(nullable: false),
                    PizzaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(nullable: false),
                    ToppingId = table.Column<Guid>(nullable: false),
                    TimeToPrepare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => new { x.CustomerId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderReviews",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    ReviewId = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    PizzaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReviews", x => new { x.OrderId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_OrderReviews_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderReviews_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrders", x => new { x.OrderId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_RestaurantOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantOrders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "City", "HouseNumber", "Name", "PhoneNumber", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("90a28cce-eb65-4e55-a485-3e26bb6869eb"), "Ieper", 373, "Ronald Steenbruggen", "0486 70 71 99", "Stationsstraat", 8900 },
                    { new Guid("691919d7-888f-4ddb-b5cd-83954b2094a9"), "Brakel", 165, "Jort Langedijk", "0472 56 03 05", "Industrieweg", 9660 }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("b3117bca-96da-463b-a433-62587fd8bd88"), "https://cdn-catalog.pizzahut.be/images/be/20170830150056964.jpg", "Margherita", 7.7000000000000002 },
                    { new Guid("6bd07325-bda2-451f-bbcb-3bf1025834c4"), "https://cdn-catalog.pizzahut.be/images/be/20170830150118476.jpg", "Pepperoni Lovers", 8.6999999999999993 },
                    { new Guid("ae4fdbb8-97a0-4c60-a16b-321ce2c135ab"), "https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg", "Hawaiian", 9.5 },
                    { new Guid("ff5c0325-1ed6-4efd-9a86-5cc780e3fa9d"), "https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg", "Barbecue Chicken", 10.199999999999999 },
                    { new Guid("2639a641-15c2-4c04-a2a3-a8539bf6789a"), "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg", "Hot 'n Spicy", 10.199999999999999 },
                    { new Guid("9afd4308-3f2d-4650-983a-1d767012915c"), "https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg", "4 Cheeses", 10.9 },
                    { new Guid("7ddbbb5b-ff70-4031-b9ff-55424b01d0d1"), "https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg", "Tuna", 9.4000000000000004 },
                    { new Guid("f885605c-6987-41f6-b009-e040e96010d9"), "https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg", "Forestiere", 10.300000000000001 },
                    { new Guid("89dc0bbc-2075-4d3b-a655-09e9905784b1"), "https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg", "Parma", 8.0999999999999996 },
                    { new Guid("0d7740cc-ddc2-4c9e-99a7-0d78765b0ae6"), "https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg", "Barbecue", 10.4 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "City", "HouseNumber", "PhoneNumber", "RestaurantName", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("6248f61e-b919-4bda-9bc0-9ee889cccc1b"), "Brugge", 160, "0471 32 89746", "The little italian", "Lange Elzenstraat", 8200 },
                    { new Guid("4d0b42c7-b7b4-44eb-a369-cfd88ca3caff"), "Ieper", 351, "0491 82 74431", "Pastasciutta", "Stationsstraat", 8900 },
                    { new Guid("e7de5a88-d7d2-43a6-aa9e-1648fb75e4f2"), "Antwerpen", 399, "0494 26 36224", "Mamma in cucina", "Herentalsebaan", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Date", "Description", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"), new DateTime(2020, 11, 8, 20, 36, 59, 783, DateTimeKind.Local).AddTicks(7888), "Fast delivery and amazingly great taste!", 4.5, "Pizzashop online" },
                    { new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"), new DateTime(2020, 11, 8, 20, 36, 59, 783, DateTimeKind.Local).AddTicks(5864), null, 4.0, "Amazing pizza!" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("16706f3d-7ed8-4aef-b8e4-528879e6afe4"), "Ham", 1.3999999999999999 },
                    { new Guid("d57f6276-045f-4482-97fd-9b06d9f8cffb"), "Mozzarella", 1.3999999999999999 },
                    { new Guid("7c1c5fdb-412a-47d0-9f97-828ffda19621"), "Pepperoni", 1.3999999999999999 },
                    { new Guid("6d6ccb96-02f1-466c-8793-0046c9b3e786"), "Champignons", 1.3999999999999999 },
                    { new Guid("a1fcea67-cea1-4c3b-a620-c214b5f4770e"), "Pineapple", 1.3999999999999999 },
                    { new Guid("bd78bd22-11b6-4b4f-bbe2-bb5efe63a2c7"), "Chilipepper", 1.3999999999999999 },
                    { new Guid("50439b1b-b37e-4e15-8ca5-f9b4f1077a28"), "Red onion", 1.3999999999999999 },
                    { new Guid("a0fd4fe8-8aa1-4b4d-a75e-80689a49ff59"), "Grilled Chicken", 1.3999999999999999 },
                    { new Guid("f462cf3c-c42a-426d-8812-834f8dbcac49"), "Barbecue sauce", 1.3999999999999999 },
                    { new Guid("16a1fa18-101d-4f91-ba66-561e6bd8331b"), "Tomato Sauce", 1.3999999999999999 },
                    { new Guid("44a954ae-e473-492d-a6c8-d1ba49a90fdf"), "Pork", 1.3999999999999999 },
                    { new Guid("3e153375-e8aa-4c4b-8836-c69213111eb0"), "Emmental", 1.3999999999999999 },
                    { new Guid("b12e92b7-843d-4f91-8363-36637af6722b"), "Goat cheese", 1.3999999999999999 },
                    { new Guid("d6ee33a1-f9c2-43e1-8386-46a623da8de9"), "Gorgonzola", 1.3999999999999999 },
                    { new Guid("2e9e2461-6853-4f79-9f8d-28ffc42b8152"), "Paprika", 1.3999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Date", "OrderType", "PizzaId", "PizzaType", "Quantity", "Size", "Time" },
                values: new object[,]
                {
                    { new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"), new DateTime(2020, 11, 8, 20, 36, 59, 779, DateTimeKind.Local).AddTicks(4950), 1, new Guid("b3117bca-96da-463b-a433-62587fd8bd88"), 0, 1, 0, 30 },
                    { new Guid("bba2eded-d219-4618-b0ce-c3a983772772"), new DateTime(2020, 11, 8, 20, 36, 59, 782, DateTimeKind.Local).AddTicks(9811), 0, new Guid("6bd07325-bda2-451f-bbcb-3bf1025834c4"), 1, 1, 1, 30 }
                });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "PizzaId", "ToppingId", "TimeToPrepare" },
                values: new object[,]
                {
                    { new Guid("b3117bca-96da-463b-a433-62587fd8bd88"), new Guid("16a1fa18-101d-4f91-ba66-561e6bd8331b"), 0 },
                    { new Guid("b3117bca-96da-463b-a433-62587fd8bd88"), new Guid("3e153375-e8aa-4c4b-8836-c69213111eb0"), 0 }
                });

            migrationBuilder.InsertData(
                table: "CustomerOrders",
                columns: new[] { "CustomerId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("691919d7-888f-4ddb-b5cd-83954b2094a9"), new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde") },
                    { new Guid("90a28cce-eb65-4e55-a485-3e26bb6869eb"), new Guid("bba2eded-d219-4618-b0ce-c3a983772772") }
                });

            migrationBuilder.InsertData(
                table: "OrderReviews",
                columns: new[] { "OrderId", "ReviewId", "PizzaId", "Subject" },
                values: new object[,]
                {
                    { new Guid("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"), new Guid("c456b9e8-d32c-4d6e-8b32-da50c5edc856"), null, null },
                    { new Guid("bba2eded-d219-4618-b0ce-c3a983772772"), new Guid("0eae9dca-640f-408e-8aa5-325f40cb3eee"), null, null }
                });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_OrderId",
                table: "CustomerOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviews_PizzaId",
                table: "OrderReviews",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviews_ReviewId",
                table: "OrderReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaId",
                table: "Orders",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_RestaurantId",
                table: "RestaurantOrders",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "OrderReviews");

            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
