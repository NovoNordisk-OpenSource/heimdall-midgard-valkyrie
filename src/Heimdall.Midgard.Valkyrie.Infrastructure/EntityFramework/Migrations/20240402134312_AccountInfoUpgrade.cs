using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AccountInfoUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "ScaffoldTask",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.Identifier);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScaffoldTask_AccountId",
                table: "ScaffoldTask",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScaffoldTask_AccountInfo_AccountId",
                table: "ScaffoldTask",
                column: "AccountId",
                principalTable: "AccountInfo",
                principalColumn: "Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScaffoldTask_AccountInfo_AccountId",
                table: "ScaffoldTask");

            migrationBuilder.DropTable(
                name: "AccountInfo");

            migrationBuilder.DropIndex(
                name: "IX_ScaffoldTask_AccountId",
                table: "ScaffoldTask");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ScaffoldTask");
        }
    }
}
