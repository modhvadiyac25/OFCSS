using Microsoft.EntityFrameworkCore.Migrations;

namespace OFCSS.Migrations
{
    public partial class justfarmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "f_id",
                table: "cropSales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "f_id",
                table: "cropSales");
        }
    }
}
