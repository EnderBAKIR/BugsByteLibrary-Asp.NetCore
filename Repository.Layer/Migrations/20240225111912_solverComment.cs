using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class solverComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SolverComment",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolverComment",
                table: "Comments");
        }
    }
}
