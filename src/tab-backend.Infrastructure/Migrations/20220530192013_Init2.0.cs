using Microsoft.EntityFrameworkCore.Migrations;

namespace tab_backend.Infrastructure.Migrations
{
    public partial class Init20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageCategories_Categories_CategoryID",
                table: "ImageCategories");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserID",
                table: "Categories",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageCategories_Categories_CategoryID",
                table: "ImageCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageCategories_Categories_CategoryID",
                table: "ImageCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageCategories_Categories_CategoryID",
                table: "ImageCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
