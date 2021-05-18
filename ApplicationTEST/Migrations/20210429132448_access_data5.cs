using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class access_data5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offres_langid",
                table: "Langues");

            migrationBuilder.RenameColumn(
                name: "langid",
                table: "Langues",
                newName: "offreid");

            migrationBuilder.RenameIndex(
                name: "IX_Langues_langid",
                table: "Langues",
                newName: "IX_Langues_offreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues",
                column: "offreid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues");

            migrationBuilder.RenameColumn(
                name: "offreid",
                table: "Langues",
                newName: "langid");

            migrationBuilder.RenameIndex(
                name: "IX_Langues_offreid",
                table: "Langues",
                newName: "IX_Langues_langid");

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offres_langid",
                table: "Langues",
                column: "langid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
