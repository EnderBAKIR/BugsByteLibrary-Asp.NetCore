using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class courseCode_addCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CourseCodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "CourseCodes");
        }
    }
}
