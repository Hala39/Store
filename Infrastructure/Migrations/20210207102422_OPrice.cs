using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class OPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Wishes");

            migrationBuilder.AddColumn<decimal>(
                name: "OPrice",
                table: "Wishes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OPrice",
                table: "Wishes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Wishes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
