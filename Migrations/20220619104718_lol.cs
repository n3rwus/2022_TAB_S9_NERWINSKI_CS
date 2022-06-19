using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABv3.Migrations
{
    public partial class lol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageCategories_Categories_CategoryId",
                table: "ImageCategories");

            migrationBuilder.DropIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_AccountId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Folders");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainFolderId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ImageFolder",
                columns: table => new
                {
                    FolderId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFolder", x => new { x.ImageId, x.FolderId });
                    table.ForeignKey(
                        name: "FK_ImageFolder_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageFolder_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AccountId",
                table: "Images",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFolder_FolderId",
                table: "ImageFolder",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders",
                column: "MainFolderId",
                principalTable: "MainFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageCategories_Categories_CategoryId",
                table: "ImageCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Accounts_AccountId",
                table: "Images",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageCategories_Categories_CategoryId",
                table: "ImageCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Accounts_AccountId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ImageFolder");

            migrationBuilder.DropIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders");

            migrationBuilder.DropIndex(
                name: "IX_Images_AccountId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFolderId",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainFolderId",
                table: "Folders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Folders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainFolders_AccountId",
                table: "MainFolders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_AccountId",
                table: "Folders",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Accounts_AccountId",
                table: "Folders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_MainFolders_MainFolderId",
                table: "Folders",
                column: "MainFolderId",
                principalTable: "MainFolders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageCategories_Categories_CategoryId",
                table: "ImageCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
