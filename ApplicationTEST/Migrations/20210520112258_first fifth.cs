using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class firstfifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examen",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nbr_questions = table.Column<int>(type: "integer", nullable: false),
                    duree = table.Column<double>(type: "double precision", nullable: false),
                    id_offre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Examen_Offre_id_offre",
                        column: x => x.id_offre,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result_Examen",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_result = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note_totale = table.Column<double>(type: "double precision", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    examenid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result_Examen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Result_Examen_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_Examen_Examen_examenid",
                        column: x => x.examenid,
                        principalTable: "Examen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note_Question",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    note_obtenue = table.Column<double>(type: "double precision", nullable: false),
                    examenid = table.Column<int>(type: "integer", nullable: true),
                    questionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note_Question", x => x.id);
                    table.ForeignKey(
                        name: "FK_Note_Question_Examen_examenid",
                        column: x => x.examenid,
                        principalTable: "Examen",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_Question_Question_questionid",
                        column: x => x.questionid,
                        principalTable: "Question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reponse = table.Column<string>(type: "text", nullable: true),
                    correcte = table.Column<bool>(type: "boolean", nullable: false),
                    questionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reponse_Question_questionid",
                        column: x => x.questionid,
                        principalTable: "Question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examen_id_offre",
                table: "Examen",
                column: "id_offre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_Question_examenid",
                table: "Note_Question",
                column: "examenid");

            migrationBuilder.CreateIndex(
                name: "IX_Note_Question_questionid",
                table: "Note_Question",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_Reponse_questionid",
                table: "Reponse",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Examen_candidatId",
                table: "Result_Examen",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Examen_examenid",
                table: "Result_Examen",
                column: "examenid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note_Question");

            migrationBuilder.DropTable(
                name: "Reponse");

            migrationBuilder.DropTable(
                name: "Result_Examen");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Examen");
        }
    }
}
