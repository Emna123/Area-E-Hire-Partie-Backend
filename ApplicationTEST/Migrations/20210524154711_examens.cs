using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class examens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examen_Offre_id_offre",
                table: "Examen");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Question_Examen_examenid",
                table: "Note_Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Examen_Examen_examenid",
                table: "Result_Examen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examen",
                table: "Examen");

            migrationBuilder.RenameTable(
                name: "Examen",
                newName: "Examens");

            migrationBuilder.RenameIndex(
                name: "IX_Examen_id_offre",
                table: "Examens",
                newName: "IX_Examens_id_offre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examens",
                table: "Examens",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens",
                column: "id_offre",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Question_Examens_examenid",
                table: "Note_Question",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Examen_Examens_examenid",
                table: "Result_Examen",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Question_Examens_examenid",
                table: "Note_Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Examen_Examens_examenid",
                table: "Result_Examen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Examens",
                table: "Examens");

            migrationBuilder.RenameTable(
                name: "Examens",
                newName: "Examen");

            migrationBuilder.RenameIndex(
                name: "IX_Examens_id_offre",
                table: "Examen",
                newName: "IX_Examen_id_offre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Examen",
                table: "Examen",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examen_Offre_id_offre",
                table: "Examen",
                column: "id_offre",
                principalTable: "Offre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Question_Examen_examenid",
                table: "Note_Question",
                column: "examenid",
                principalTable: "Examen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Examen_Examen_examenid",
                table: "Result_Examen",
                column: "examenid",
                principalTable: "Examen",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
