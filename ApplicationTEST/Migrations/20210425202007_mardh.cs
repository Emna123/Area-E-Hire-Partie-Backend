using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class mardh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "offreid",
                table: "Langues",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "offreid",
                table: "Competences",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    type_offre = table.Column<string>(type: "text", nullable: true),
                    type_contrat = table.Column<string>(type: "text", nullable: true),
                    lieu_travail = table.Column<string>(type: "text", nullable: true),
                    nbr_poste = table.Column<string>(type: "text", nullable: true),
                    annee_exp = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    date_publication = table.Column<string>(type: "text", nullable: true),
                    date_expiration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Diplomes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    offreid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diplomes_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Langues_offreid",
                table: "Langues",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_offreid",
                table: "Competences",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomes_offreid",
                table: "Diplomes",
                column: "offreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues");

            migrationBuilder.DropTable(
                name: "Diplomes");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropIndex(
                name: "IX_Langues_offreid",
                table: "Langues");

            migrationBuilder.DropIndex(
                name: "IX_Competences_offreid",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "offreid",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "offreid",
                table: "Competences");
        }
    }
}
