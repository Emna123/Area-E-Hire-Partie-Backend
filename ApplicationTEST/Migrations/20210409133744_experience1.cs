using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class experience1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "typeEmploi",
                table: "Experience_prof",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeEmploi",
                table: "Experience_prof");
        }
    }
}
