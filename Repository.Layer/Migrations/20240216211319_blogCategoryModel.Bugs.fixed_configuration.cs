using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class blogCategoryModelBugsfixed_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsCategories_Blogs_BlogId",
                table: "BlogsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsCategories_Categories_CategoryId",
                table: "BlogsCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsCategories_Blogs_BlogId",
                table: "BlogsCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsCategories_Categories_CategoryId",
                table: "BlogsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsCategories_Blogs_BlogId",
                table: "BlogsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogsCategories_Categories_CategoryId",
                table: "BlogsCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsCategories_Blogs_BlogId",
                table: "BlogsCategories",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsCategories_Categories_CategoryId",
                table: "BlogsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
