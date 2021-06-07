using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class update_note_question_final1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Questions_AspNetUsers_candidatId",
                table: "Notes_Questions");

            migrationBuilder.DropIndex(
                name: "IX_Notes_Questions_candidatId",
                table: "Notes_Questions");

            migrationBuilder.DropColumn(
                name: "candidatId",
                table: "Notes_Questions");

            migrationBuilder.DropColumn(
                name: "note_obtenue",
                table: "Notes_Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "candidatId",
                table: "Notes_Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "note_obtenue",
                table: "Notes_Questions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Questions_candidatId",
                table: "Notes_Questions",
                column: "candidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Questions_AspNetUsers_candidatId",
                table: "Notes_Questions",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
