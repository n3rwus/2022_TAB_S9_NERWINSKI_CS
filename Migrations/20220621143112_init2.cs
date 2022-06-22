using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABv3.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders");

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_FolderId",
                table: "Images",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Folders_FolderId",
                table: "Images",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Folders_FolderId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_FolderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
