using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examens_Examenid",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Examenid",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Examenid",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Examenid",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Examenid",
                table: "Questions",
                column: "Examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examens_Examenid",
                table: "Questions",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
