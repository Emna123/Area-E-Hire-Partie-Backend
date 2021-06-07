using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Offre_id_offre",
                table: "Examen");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Question_Examen_examenid",
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
                name: "FK_Result_Examen_Examen_examenid",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examen",
                table: "Examen");

            migrationBuilder.RenameTable(
                name: "Result_Examen",
                newName: "Results_Examens");

            migrationBuilder.RenameTable(
                name: "Reponse",
                newName: "Reponses");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Note_Question",
                newName: "Notes_Examens");

            migrationBuilder.RenameTable(
                name: "Examen",
                newName: "Examens");

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
                table: "Reponses",
                newName: "IX_Reponses_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Question_questionid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Note_Question_examenid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Examen_id_offre",
                table: "Examens",
                newName: "IX_Examens_id_offre");

            migrationBuilder.AddColumn<int>(
                name: "examenid",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results_Examens",
                table: "Results_Examens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examens",
                table: "Examens",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_examenid",
                table: "Questions",
                column: "examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens",
                column: "id_offre",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Questions_Examens_examenid",
                table: "Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reponses_Questions_questionid",
                table: "Reponses",
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
                name: "FK_Examens_Offre_id_offre",
                table: "Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examens_examenid",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reponses_Questions_questionid",
                table: "Reponses");

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
                name: "PK_Reponses",
                table: "Reponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_examenid",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examens",
                table: "Examens");

            migrationBuilder.DropColumn(
                name: "examenid",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Results_Examens",
                newName: "Result_Examen");

            migrationBuilder.RenameTable(
                name: "Reponses",
                newName: "Reponse");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Notes_Examens",
                newName: "Note_Question");

            migrationBuilder.RenameTable(
                name: "Examens",
                newName: "Examen");

            migrationBuilder.RenameIndex(
                name: "IX_Results_Examens_examenid",
                table: "Result_Examen",
                newName: "IX_Result_Examen_examenid");

            migrationBuilder.RenameIndex(
                name: "IX_Results_Examens_candidatId",
                table: "Result_Examen",
                newName: "IX_Result_Examen_candidatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reponses_questionid",
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

            migrationBuilder.RenameIndex(
                name: "IX_Examens_id_offre",
                table: "Examen",
                newName: "IX_Examen_id_offre");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examen",
                table: "Examen",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Offre_id_offre",
                table: "Examen",
                column: "id_offre",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Question_Examen_examenid",
                table: "Note_Question",
                column: "examenid",
                principalTable: "Examen",
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
                name: "FK_Result_Examen_Examen_examenid",
                table: "Result_Examen",
                column: "examenid",
                principalTable: "Examen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
