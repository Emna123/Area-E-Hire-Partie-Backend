using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class experience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "candidatId",
                table: "Experience_prof",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experience_prof_candidatId",
                table: "Experience_prof",
                column: "candidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_prof_AspNetUsers_candidatId",
                table: "Experience_prof",
                column: "candidatId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_prof_AspNetUsers_candidatId",
                table: "Experience_prof");

            migrationBuilder.DropIndex(
                name: "IX_Experience_prof_candidatId",
                table: "Experience_prof");

            migrationBuilder.DropColumn(
                name: "candidatId",
                table: "Experience_prof");
        }
    }
}
