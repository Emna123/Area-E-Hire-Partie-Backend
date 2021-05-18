using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class access_data3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues");

            migrationBuilder.DropIndex(
                name: "IX_Langues_offreid",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "offreid",
                table: "Langues");

            migrationBuilder.CreateIndex(
                name: "IX_Langues_langid",
                table: "Langues",
                column: "langid");

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offres_langid",
                table: "Langues",
                column: "langid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langues_Offres_langid",
                table: "Langues");

            migrationBuilder.DropIndex(
                name: "IX_Langues_langid",
                table: "Langues");

            migrationBuilder.AddColumn<int>(
                name: "offreid",
                table: "Langues",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Langues_offreid",
                table: "Langues",
                column: "offreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_Offres_offreid",
                table: "Langues",
                column: "offreid",
                principalTable: "Offres",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
