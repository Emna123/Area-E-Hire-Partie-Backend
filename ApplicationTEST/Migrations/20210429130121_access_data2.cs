using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class access_data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "langid",
                table: "Langues",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "langid",
                table: "Langues");
        }
    }
}
