using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABv3.Migrations
{
    public partial class TABV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders");

            migrationBuilder.DropColumn(
                name: "MainFolderId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders");

            migrationBuilder.AddColumn<int>(
                name: "MainFolderId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders",
                column: "AccountId",
                unique: true);
        }
    }
}
