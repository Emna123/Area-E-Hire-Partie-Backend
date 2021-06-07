using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class last_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examens_Offre_id_offre",
                table: "Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Examens_id_offre",
                table: "Examens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens");

            migrationBuilder.DropColumn(
                name: "id_offre",
                table: "Examens");

            migrationBuilder.RenameTable(
                name: "Notes_Examens",
                newName: "Notes_Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_questionid",
                table: "Notes_Questions",
                newName: "IX_Notes_Questions_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Examens_examenid",
                table: "Notes_Questions",
                newName: "IX_Notes_Questions_examenid");

            migrationBuilder.AddColumn<int>(
                name: "Examenid",
                table: "Results_Examens",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Examenid",
                table: "Offre",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes_Questions",
                table: "Notes_Questions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Examens_Examenid",
                table: "Results_Examens",
                column: "Examenid");

            migrationBuilder.CreateIndex(
                name: "IX_Offre_Examenid",
                table: "Offre",
                column: "Examenid");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Questions_Examens_examenid",
                table: "Notes_Questions",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Questions_Questions_questionid",
                table: "Notes_Questions",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offre_Examens_Examenid",
                table: "Offre",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_Examens_Examenid",
                table: "Results_Examens",
                column: "Examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Questions_Examens_examenid",
                table: "Notes_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Questions_Questions_questionid",
                table: "Notes_Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Offre_Examens_Examenid",
                table: "Offre");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_Examens_Examenid",
                table: "Results_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Results_Examens_Examenid",
                table: "Results_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Offre_Examenid",
                table: "Offre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes_Questions",
                table: "Notes_Questions");

            migrationBuilder.DropColumn(
                name: "Examenid",
                table: "Results_Examens");

            migrationBuilder.DropColumn(
                name: "Examenid",
                table: "Offre");

            migrationBuilder.RenameTable(
                name: "Notes_Questions",
                newName: "Notes_Examens");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Questions_questionid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_Questions_examenid",
                table: "Notes_Examens",
                newName: "IX_Notes_Examens_examenid");

            migrationBuilder.AddColumn<int>(
                name: "id_offre",
                table: "Examens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes_Examens",
                table: "Notes_Examens",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Examens_Examens_examenid",
                table: "Notes_Examens",
                column: "examenid",
                principalTable: "Examens",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Examens_Questions_questionid",
                table: "Notes_Examens",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
