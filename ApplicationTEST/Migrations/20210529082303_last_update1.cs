using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class last_update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_Examens_Examenid",
                table: "Results_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Results_Examens_Examenid",
                table: "Results_Examens");

            migrationBuilder.DropColumn(
                name: "Examenid",
                table: "Results_Examens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Examenid",
                table: "Results_Examens",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_Examens_Examenid",
                table: "Results_Examens",
                column: "Examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_Examens_Examenid",
                table: "Results_Examens",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
