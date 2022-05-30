using Microsoft.EntityFrameworkCore.Migrations;

namespace tab_backend.Infrastructure.Migrations
{
    public partial class MainFolderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderID",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserID",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Folders");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Folders",
                newName: "MainFolderID");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_UserID",
                table: "Folders",
                newName: "IX_Folders_MainFolderID");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderID",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MainFolder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainFolder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MainFolder_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainFolder_UserID",
                table: "MainFolder",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderID",
                table: "Folders",
                column: "ParentFolderID",
                principalTable: "Folders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_MainFolder_MainFolderID",
                table: "Folders",
                column: "MainFolderID",
                principalTable: "MainFolder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderID",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_MainFolder_MainFolderID",
                table: "Folders");

            migrationBuilder.DropTable(
                name: "MainFolder");

            migrationBuilder.RenameColumn(
                name: "MainFolderID",
                table: "Folders",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_MainFolderID",
                table: "Folders",
                newName: "IX_Folders_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderID",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderID",
                table: "Folders",
                column: "ParentFolderID",
                principalTable: "Folders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserID",
                table: "Folders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
