using Microsoft.EntityFrameworkCore.Migrations;

namespace OFCSS.Migrations
{
    public partial class firstinitwith_ofcss_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_merchants_merchantRequirments_MerchantRequirmentmr_id",
                table: "merchants");

            migrationBuilder.DropIndex(
                name: "IX_merchants_MerchantRequirmentmr_id",
                table: "merchants");

            migrationBuilder.DropColumn(
                name: "MerchantRequirmentmr_id",
                table: "merchants");

            migrationBuilder.DropColumn(
                name: "mr_id",
                table: "merchants");

            migrationBuilder.AddColumn<int>(
                name: "Merchantm_id",
                table: "merchantRequirments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "m_id",
                table: "merchantRequirments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_merchantRequirments_Merchantm_id",
                table: "merchantRequirments",
                column: "Merchantm_id");

            migrationBuilder.AddForeignKey(
                name: "FK_merchantRequirments_merchants_Merchantm_id",
                table: "merchantRequirments",
                column: "Merchantm_id",
                principalTable: "merchants",
                principalColumn: "m_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_merchantRequirments_merchants_Merchantm_id",
                table: "merchantRequirments");

            migrationBuilder.DropIndex(
                name: "IX_merchantRequirments_Merchantm_id",
                table: "merchantRequirments");

            migrationBuilder.DropColumn(
                name: "Merchantm_id",
                table: "merchantRequirments");

            migrationBuilder.DropColumn(
                name: "m_id",
                table: "merchantRequirments");

            migrationBuilder.AddColumn<int>(
                name: "MerchantRequirmentmr_id",
                table: "merchants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mr_id",
                table: "merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_merchants_MerchantRequirmentmr_id",
                table: "merchants",
                column: "MerchantRequirmentmr_id");

            migrationBuilder.AddForeignKey(
                name: "FK_merchants_merchantRequirments_MerchantRequirmentmr_id",
                table: "merchants",
                column: "MerchantRequirmentmr_id",
                principalTable: "merchantRequirments",
                principalColumn: "mr_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
