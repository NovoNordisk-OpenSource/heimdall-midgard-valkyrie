using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class StatusUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ScaffoldTask",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScaffoldTask_StatusId",
                table: "ScaffoldTask",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScaffoldTask_BuildStatus_StatusId",
                table: "ScaffoldTask",
                column: "StatusId",
                principalTable: "BuildStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScaffoldTask_BuildStatus_StatusId",
                table: "ScaffoldTask");

            migrationBuilder.DropTable(
                name: "BuildStatus");

            migrationBuilder.DropIndex(
                name: "IX_ScaffoldTask_StatusId",
                table: "ScaffoldTask");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ScaffoldTask");
        }
    }
}
