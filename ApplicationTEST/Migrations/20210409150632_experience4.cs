using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class experience4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "poste_occupe",
                table: "Experience_prof",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lieu_Exp",
                table: "Experience_prof",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "poste_occupe",
                table: "Experience_prof",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lieu_Exp",
                table: "Experience_prof",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
