using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CandidatId",
                table: "Offre",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offre_CandidatId",
                table: "Offre",
                column: "CandidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offre_AspNetUsers_CandidatId",
                table: "Offre",
                column: "CandidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offre_AspNetUsers_CandidatId",
                table: "Offre");

            migrationBuilder.DropIndex(
                name: "IX_Offre_CandidatId",
                table: "Offre");

            migrationBuilder.DropColumn(
                name: "CandidatId",
                table: "Offre");
        }
    }
}
