using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens");

            migrationBuilder.RenameTable(
                name: "Notes_Examens",
                newName: "Note_Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_questionid",
                table: "Note_Questions",
                newName: "IX_Note_Questions_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_examenid",
                table: "Note_Questions",
                newName: "IX_Note_Questions_examenid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note_Questions",
                table: "Note_Questions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Questions_Questions_questionid",
                table: "Note_Questions",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Questions_Questions_questionid",
                table: "Note_Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note_Questions",
                table: "Note_Questions");

            migrationBuilder.RenameTable(
                name: "Note_Questions",
                newName: "Notes_Examens");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Questions_questionid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Questions_examenid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_examenid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
