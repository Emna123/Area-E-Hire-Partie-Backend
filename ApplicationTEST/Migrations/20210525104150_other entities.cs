using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class otherentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Question_Examens_examenid",
                table: "Note_Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Question_Question_questionid",
                table: "Note_Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Question_questionid",
                table: "Reponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Examen_AspNetUsers_candidatId",
                table: "Result_Examen");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Examen_Examens_examenid",
                table: "Result_Examen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result_Examen",
                table: "Result_Examen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reponse",
                table: "Reponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note_Question",
                table: "Note_Question");

            migrationBuilder.RenameTable(
                name: "Result_Examen",
                newName: "Results_Examens");

            migrationBuilder.RenameTable(
                name: "Reponse",
                newName: "Responses");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Note_Question",
                newName: "Notes_Examens");

            migrationBuilder.RenameIndex(
                name: "IX_Result_Examen_examenid",
                table: "Results_Examens",
                newName: "IX_Results_Examens_examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Result_Examen_candidatId",
                table: "Results_Examens",
                newName: "IX_Results_Examens_candidatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reponse_questionid",
                table: "Responses",
                newName: "IX_Responses_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Question_questionid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Question_examenid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_examenid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results_Examens",
                table: "Results_Examens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_questionid",
                table: "Responses",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_AspNetUsers_candidatId",
                table: "Results_Examens",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_questionid",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_AspNetUsers_candidatId",
                table: "Results_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results_Examens",
                table: "Results_Examens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens");

            migrationBuilder.RenameTable(
                name: "Results_Examens",
                newName: "Result_Examen");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Reponse");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Notes_Examens",
                newName: "Note_Question");

            migrationBuilder.RenameIndex(
                name: "IX_Results_Examens_examenid",
                table: "Result_Examen",
                newName: "IX_Result_Examen_examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Results_Examens_candidatId",
                table: "Result_Examen",
                newName: "IX_Result_Examen_candidatId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_questionid",
                table: "Reponse",
                newName: "IX_Reponse_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_questionid",
                table: "Note_Question",
                newName: "IX_Note_Question_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_examenid",
                table: "Note_Question",
                newName: "IX_Note_Question_examenid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result_Examen",
                table: "Result_Examen",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponse",
                table: "Reponse",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note_Question",
                table: "Note_Question",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Question_Examens_examenid",
                table: "Note_Question",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Question_Question_questionid",
                table: "Note_Question",
                column: "questionid",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Question_questionid",
                table: "Reponse",
                column: "questionid",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Examen_AspNetUsers_candidatId",
                table: "Result_Examen",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Examen_Examens_examenid",
                table: "Result_Examen",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
