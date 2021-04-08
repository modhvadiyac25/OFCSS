using Microsoft.EntityFrameworkCore.Migrations;

namespace OFCSS.Migrations
{
    public partial class init_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "m_id",
                table: "merchantRequirments");

            migrationBuilder.DropColumn(
                name: "f_id",
                table: "cropSales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "m_id",
                table: "merchantRequirments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "f_id",
                table: "cropSales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
