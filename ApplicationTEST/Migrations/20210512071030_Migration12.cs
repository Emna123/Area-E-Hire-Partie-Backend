using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "candidatId",
                table: "Candidature",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_candidatId",
                table: "Candidature",
                column: "candidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidature_AspNetUsers_candidatId",
                table: "Candidature",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidature_AspNetUsers_candidatId",
                table: "Candidature");

            migrationBuilder.DropIndex(
                name: "IX_Candidature_candidatId",
                table: "Candidature");

            migrationBuilder.DropColumn(
                name: "candidatId",
                table: "Candidature");
        }
    }
}
