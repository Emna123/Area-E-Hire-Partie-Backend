using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class changement_global : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formation_AspNetUsers_candidatId",
                table: "Formation");

            migrationBuilder.DropForeignKey(
                name: "FK_Formation_Generer_id_generer",
                table: "Formation");

            migrationBuilder.DropIndex(
                name: "IX_Generer_CandidatId",
                table: "Generer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formation",
                table: "Formation");

            migrationBuilder.RenameTable(
                name: "Formation",
                newName: "Formations");

            migrationBuilder.RenameIndex(
                name: "IX_Formation_id_generer",
                table: "Formations",
                newName: "IX_Formations_id_generer");

            migrationBuilder.RenameIndex(
                name: "IX_Formation_candidatId",
                table: "Formations",
                newName: "IX_Formations_candidatId");

            migrationBuilder.AddColumn<string>(
                name: "adresse",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "date_naissance",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formations",
                table: "Formations",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Linkedins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    linkedin = table.Column<string>(type: "text", nullable: true),
                    id_candidat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linkedins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Linkedins_AspNetUsers_id_candidat",
                        column: x => x.id_candidat,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generer_CandidatId",
                table: "Generer",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Linkedins_id_candidat",
                table: "Linkedins",
                column: "id_candidat",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_AspNetUsers_candidatId",
                table: "Formations",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Generer_id_generer",
                table: "Formations",
                column: "id_generer",
                principalTable: "Generer",
                principalColumn: "id_generer",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_AspNetUsers_candidatId",
                table: "Formations");

            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Generer_id_generer",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "Linkedins");

            migrationBuilder.DropIndex(
                name: "IX_Generer_CandidatId",
                table: "Generer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formations",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "adresse",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "date_naissance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "description",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Formations",
                newName: "Formation");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_id_generer",
                table: "Formation",
                newName: "IX_Formation_id_generer");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_candidatId",
                table: "Formation",
                newName: "IX_Formation_candidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formation",
                table: "Formation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Generer_CandidatId",
                table: "Generer",
                column: "CandidatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_AspNetUsers_candidatId",
                table: "Formation",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_Generer_id_generer",
                table: "Formation",
                column: "id_generer",
                principalTable: "Generer",
                principalColumn: "id_generer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
