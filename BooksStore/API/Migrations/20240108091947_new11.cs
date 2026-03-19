using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class new11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_BrandDetails_BrandId",
                table: "BookDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandDetails",
                table: "BrandDetails");

            migrationBuilder.RenameTable(
                name: "BrandDetails",
                newName: "BrandDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandDetail",
                table: "BrandDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_BrandDetail_BrandId",
                table: "BookDetails",
                column: "BrandId",
                principalTable: "BrandDetail",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_BrandDetail_BrandId",
                table: "BookDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandDetail",
                table: "BrandDetail");

            migrationBuilder.RenameTable(
                name: "BrandDetail",
                newName: "BrandDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandDetails",
                table: "BrandDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_BrandDetails_BrandId",
                table: "BookDetails",
                column: "BrandId",
                principalTable: "BrandDetails",
                principalColumn: "Id");
        }
    }
}
