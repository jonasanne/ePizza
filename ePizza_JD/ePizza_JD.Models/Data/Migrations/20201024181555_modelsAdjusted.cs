using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.WebApp.Data.Migrations
{
    public partial class modelsAdjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Toppings",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Toppings",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
