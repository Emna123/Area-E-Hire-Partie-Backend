using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_AspNetUsers_candidatId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Diplome_Offre_offreid",
                table: "Diplome");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaire_Offre_offreid",
                table: "Questionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competences",
                table: "Competences");

            migrationBuilder.RenameTable(
                name: "Competences",
                newName: "Competence");

            migrationBuilder.RenameIndex(
                name: "IX_Competences_offreid",
                table: "Competence",
                newName: "IX_Competence_offreid");

            migrationBuilder.RenameIndex(
                name: "IX_Competences_candidatId",
                table: "Competence",
                newName: "IX_Competence_candidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competence",
                table: "Competence",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competence_AspNetUsers_candidatId",
                table: "Competence",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competence_Offre_offreid",
                table: "Competence",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diplome_Offre_offreid",
                table: "Diplome",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaire_Offre_offreid",
                table: "Questionnaire",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competence_AspNetUsers_candidatId",
                table: "Competence");

            migrationBuilder.DropForeignKey(
                name: "FK_Competence_Offre_offreid",
                table: "Competence");

            migrationBuilder.DropForeignKey(
                name: "FK_Diplome_Offre_offreid",
                table: "Diplome");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaire_Offre_offreid",
                table: "Questionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competence",
                table: "Competence");

            migrationBuilder.RenameTable(
                name: "Competence",
                newName: "Competences");

            migrationBuilder.RenameIndex(
                name: "IX_Competence_offreid",
                table: "Competences",
                newName: "IX_Competences_offreid");

            migrationBuilder.RenameIndex(
                name: "IX_Competence_candidatId",
                table: "Competences",
                newName: "IX_Competences_candidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competences",
                table: "Competences",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_AspNetUsers_candidatId",
                table: "Competences",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diplome_Offre_offreid",
                table: "Diplome",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaire_Offre_offreid",
                table: "Questionnaire",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
