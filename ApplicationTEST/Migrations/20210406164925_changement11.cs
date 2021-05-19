using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class changement11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langue_AspNetUsers_candidatId",
                table: "Langue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Langue",
                table: "Langue");

            migrationBuilder.RenameTable(
                name: "Langue",
                newName: "Langues");

            migrationBuilder.RenameIndex(
                name: "IX_Langue_candidatId",
                table: "Langues",
                newName: "IX_Langues_candidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Langues",
                table: "Langues",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_AspNetUsers_candidatId",
                table: "Langues",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langues_AspNetUsers_candidatId",
                table: "Langues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Langues",
                table: "Langues");

            migrationBuilder.RenameTable(
                name: "Langues",
                newName: "Langue");

            migrationBuilder.RenameIndex(
                name: "IX_Langues_candidatId",
                table: "Langue",
                newName: "IX_Langue_candidatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Langue",
                table: "Langue",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Langue_AspNetUsers_candidatId",
                table: "Langue",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
