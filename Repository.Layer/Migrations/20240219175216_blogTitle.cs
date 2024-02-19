using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class blogTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EBooks_AspNetUsers_AppUserId",
                table: "EBooks");

            migrationBuilder.DropIndex(
                name: "IX_EBooks_AppUserId",
                table: "EBooks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "EBooks");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "EBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EBooks_AppUserId",
                table: "EBooks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EBooks_AspNetUsers_AppUserId",
                table: "EBooks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
