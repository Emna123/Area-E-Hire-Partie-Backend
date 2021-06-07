using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Questions_Examens_examenid",
                table: "Note_Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_Examens_examenid",
                table: "Results_Examens",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
