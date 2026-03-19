using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class _111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Products_ProductId",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "BookDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Products_ProductId",
                table: "BookDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Products_ProductId",
                table: "BookDetails");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "BookDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Products_ProductId",
                table: "BookDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
