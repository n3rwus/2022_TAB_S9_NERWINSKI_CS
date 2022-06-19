using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABv3.Migrations
{
    public partial class DBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "MainFolderId",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders",
                column: "MainFolderId",
                principalTable: "MainFolders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "MainFolderId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders",
                column: "MainFolderId",
                principalTable: "MainFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
