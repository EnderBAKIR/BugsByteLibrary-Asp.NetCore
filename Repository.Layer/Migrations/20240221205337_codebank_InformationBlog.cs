using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class codebank_InformationBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "Content");

            migrationBuilder.AddColumn<bool>(
                name: "CodeBank",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InformationBlog",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeBank",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "InformationBlog",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Blogs",
                newName: "Title");
        }
    }
}
