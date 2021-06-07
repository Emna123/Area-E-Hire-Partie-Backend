using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class Migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens");

            migrationBuilder.DropIndex(
                name: "IX_Examens_id_offre",
                table: "Examens");

            migrationBuilder.DropColumn(
                name: "id_offre",
                table: "Examens");

            migrationBuilder.AddColumn<int>(
                name: "Examenid",
                table: "Offre",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offre_Examenid",
                table: "Offre",
                column: "Examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offre_Examens_Examenid",
                table: "Offre",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offre_Examens_Examenid",
                table: "Offre");

            migrationBuilder.DropIndex(
                name: "IX_Offre_Examenid",
                table: "Offre");

            migrationBuilder.DropColumn(
                name: "Examenid",
                table: "Offre");

            migrationBuilder.AddColumn<int>(
                name: "id_offre",
                table: "Examens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Examens_id_offre",
                table: "Examens",
                column: "id_offre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens",
                column: "id_offre",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
