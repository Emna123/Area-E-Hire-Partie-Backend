using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class reponses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_questionid",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Reponses");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_questionid",
                table: "Reponses",
                newName: "IX_Reponses_questionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reponses_Questions_questionid",
                table: "Reponses",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reponses_Questions_questionid",
                table: "Reponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reponses",
                table: "Reponses");

            migrationBuilder.RenameTable(
                name: "Reponses",
                newName: "Responses");

            migrationBuilder.RenameIndex(
                name: "IX_Reponses_questionid",
                table: "Responses",
                newName: "IX_Responses_questionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_questionid",
                table: "Responses",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
