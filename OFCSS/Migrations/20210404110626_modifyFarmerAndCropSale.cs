using Microsoft.EntityFrameworkCore.Migrations;

namespace OFCSS.Migrations
{
    public partial class modifyFarmerAndCropSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmers_cropSales_CropSalec_id",
                table: "farmers");

            migrationBuilder.DropIndex(
                name: "IX_farmers_CropSalec_id",
                table: "farmers");

            migrationBuilder.DropColumn(
                name: "CropSalec_id",
                table: "farmers");

            migrationBuilder.DropColumn(
                name: "c_id",
                table: "farmers");

            migrationBuilder.AddColumn<int>(
                name: "Farmerf_id",
                table: "cropSales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "f_id",
                table: "cropSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreateCropSaleViewModel",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cquantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cprice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cdiscription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateCropSaleViewModel", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "CreateRoleViewModel",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateRoleViewModel", x => x.RoleName);
                });

            migrationBuilder.CreateTable(
                name: "LoginViewModel",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginViewModel", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    rid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usertype = table.Column<bool>(type: "bit", nullable: false),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taluka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    village = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirm_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.rid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cropSales_Farmerf_id",
                table: "cropSales",
                column: "Farmerf_id");

            migrationBuilder.AddForeignKey(
                name: "FK_cropSales_farmers_Farmerf_id",
                table: "cropSales",
                column: "Farmerf_id",
                principalTable: "farmers",
                principalColumn: "f_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cropSales_farmers_Farmerf_id",
                table: "cropSales");

            migrationBuilder.DropTable(
                name: "CreateCropSaleViewModel");

            migrationBuilder.DropTable(
                name: "CreateRoleViewModel");

            migrationBuilder.DropTable(
                name: "LoginViewModel");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropIndex(
                name: "IX_cropSales_Farmerf_id",
                table: "cropSales");

            migrationBuilder.DropColumn(
                name: "Farmerf_id",
                table: "cropSales");

            migrationBuilder.DropColumn(
                name: "f_id",
                table: "cropSales");

            migrationBuilder.AddColumn<int>(
                name: "CropSalec_id",
                table: "farmers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "c_id",
                table: "farmers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_farmers_CropSalec_id",
                table: "farmers",
                column: "CropSalec_id");

            migrationBuilder.AddForeignKey(
                name: "FK_farmers_cropSales_CropSalec_id",
                table: "farmers",
                column: "CropSalec_id",
                principalTable: "cropSales",
                principalColumn: "c_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
