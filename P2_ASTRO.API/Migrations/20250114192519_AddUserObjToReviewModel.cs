using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2_ASTRO.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserObjToReviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PODs_PODId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PODId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PODId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "PODId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PODId",
                table: "Users",
                column: "PODId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PODs_PODId",
                table: "Users",
                column: "PODId",
                principalTable: "PODs",
                principalColumn: "PODId");
        }
    }
}
