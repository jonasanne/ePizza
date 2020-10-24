using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.WebApp.Data.Migrations
{
    public partial class sizeInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pizzas");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Pizzas",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Orders");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Pizzas",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
