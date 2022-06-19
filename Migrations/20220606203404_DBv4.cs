using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABv3.Migrations
{
    public partial class DBv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainFolders_Accounts_Id",
                table: "MainFolders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MainFolders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainFolders_Accounts_AccountId",
                table: "MainFolders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainFolders_Accounts_AccountId",
                table: "MainFolders");

            migrationBuilder.DropIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MainFolders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_MainFolders_Accounts_Id",
                table: "MainFolders",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
