using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.Models.Migrations
{
    public partial class newTablesRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_RestaurantId",
                table: "RestaurantOrders",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
