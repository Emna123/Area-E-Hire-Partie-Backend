using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class idkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    niveau = table.Column<string>(type: "text", nullable: true),
                    candidatId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.id);
                    table.ForeignKey(
                        name: "FK_Competences_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competences_candidatId",
                table: "Competences",
                column: "candidatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competences");
        }
    }
}
