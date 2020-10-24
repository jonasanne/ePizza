using Microsoft.EntityFrameworkCore.Migrations;

namespace ePizza_JD.Models.Migrations
{
    public partial class changeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Reviews",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
