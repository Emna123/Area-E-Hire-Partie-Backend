using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class mardh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Diplomes_Offre_offreid",
                table: "Diplomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offre_offreid",
                table: "Langues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offre",
                table: "Offre");

            migrationBuilder.RenameTable(
                name: "Offre",
                newName: "Offres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offres",
                table: "Offres",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Offres_offreid",
                table: "Competences",
                column: "offreid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomes_Offres_offreid",
                table: "Diplomes",
                column: "offreid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues",
                column: "offreid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Offres_offreid",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_Diplomes_Offres_offreid",
                table: "Diplomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offres",
                table: "Offres");

            migrationBuilder.RenameTable(
                name: "Offres",
                newName: "Offre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offre",
                table: "Offre",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Offre_offreid",
                table: "Competences",
                column: "offreid",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomes_Offre_offreid",
                table: "Diplomes",
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
    }
}
