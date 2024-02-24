using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class hiring_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Hirings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Hirings");
        }
    }
}
