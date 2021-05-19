using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class formation22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date_fin",
                table: "Formation",
                newName: "annee_fin");

            migrationBuilder.RenameColumn(
                name: "date_debut",
                table: "Formation",
                newName: "annee_debut");

            migrationBuilder.RenameColumn(
                name: "id_formation",
                table: "Formation",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "candidatId",
                table: "Formation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Formation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formation_candidatId",
                table: "Formation",
                column: "candidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_AspNetUsers_candidatId",
                table: "Formation",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formation_AspNetUsers_candidatId",
                table: "Formation");

            migrationBuilder.DropIndex(
                name: "IX_Formation_candidatId",
                table: "Formation");

            migrationBuilder.DropColumn(
                name: "candidatId",
                table: "Formation");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Formation");

            migrationBuilder.RenameColumn(
                name: "annee_fin",
                table: "Formation",
                newName: "date_fin");

            migrationBuilder.RenameColumn(
                name: "annee_debut",
                table: "Formation",
                newName: "date_debut");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Formation",
                newName: "id_formation");
        }
    }
}
