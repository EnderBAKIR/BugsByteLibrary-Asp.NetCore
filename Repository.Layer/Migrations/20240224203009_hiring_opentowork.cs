using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class hiring_opentowork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hirings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hirings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenToWorks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVPdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiringId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenToWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenToWorks_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenToWorks_Hirings_HiringId",
                        column: x => x.HiringId,
                        principalTable: "Hirings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenToWorks_AppUserId",
                table: "OpenToWorks",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenToWorks_HiringId",
                table: "OpenToWorks",
                column: "HiringId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenToWorks");

            migrationBuilder.DropTable(
                name: "Hirings");
        }
    }
}
