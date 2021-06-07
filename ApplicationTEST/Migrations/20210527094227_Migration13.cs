using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examens_examenid",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "examenid",
                table: "Questions",
                newName: "Examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_examenid",
                table: "Questions",
                newName: "IX_Questions_Examenid");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_expiration",
                table: "Examens",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "passed",
                table: "Examens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examens_Examenid",
                table: "Questions",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examens_Examenid",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "date_expiration",
                table: "Examens");

            migrationBuilder.DropColumn(
                name: "passed",
                table: "Examens");

            migrationBuilder.RenameColumn(
                name: "Examenid",
                table: "Questions",
                newName: "examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_Examenid",
                table: "Questions",
                newName: "IX_Questions_examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examens_examenid",
                table: "Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
