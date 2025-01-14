using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2_ASTRO.API.Migrations
{
    /// <inheritdoc />
    public partial class model_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PODs_PODId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_PODId",
                table: "Reviews",
                newName: "IX_Reviews_PODId");

            migrationBuilder.AddColumn<int>(
                name: "PODId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Copyright",
                table: "PODs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentTime",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PODId",
                table: "Users",
                column: "PODId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_PODs_PODId",
                table: "Reviews",
                column: "PODId",
                principalTable: "PODs",
                principalColumn: "PODId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PODs_PODId",
                table: "Users",
                column: "PODId",
                principalTable: "PODs",
                principalColumn: "PODId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_PODs_PODId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PODs_PODId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PODId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PODId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Copyright",
                table: "PODs");

            migrationBuilder.DropColumn(
                name: "CommentTime",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PODId",
                table: "Contacts",
                newName: "IX_Contacts_PODId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PODs_PODId",
                table: "Contacts",
                column: "PODId",
                principalTable: "PODs",
                principalColumn: "PODId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
