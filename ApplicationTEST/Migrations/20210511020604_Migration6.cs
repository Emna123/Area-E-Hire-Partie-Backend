using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etat = table.Column<string>(type: "text", nullable: true),
                    nom = table.Column<string>(type: "text", nullable: true),
                    prenom = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    date_candidature = table.Column<string>(type: "text", nullable: true),
                    lettre_motivation = table.Column<string>(type: "text", nullable: true),
                    salaire_demande = table.Column<string>(type: "text", nullable: true),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    offreid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => x.id);
                    table.ForeignKey(
                        name: "FK_Candidature_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidature_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_candidatId",
                table: "Candidature",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_offreid",
                table: "Candidature",
                column: "offreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Competence_Offre_offreid",
                table: "Competence",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Candidature");

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
    }
}
