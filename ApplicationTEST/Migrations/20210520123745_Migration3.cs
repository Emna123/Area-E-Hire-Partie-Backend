using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsable_RH",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "e_mail",
                table: "Responsable_RH");

            migrationBuilder.RenameColumn(
                name: "id_resp",
                table: "Responsable_RH",
                newName: "AccessFailedCount");

            migrationBuilder.AlterColumn<string>(
                name: "mdp",
                table: "Responsable_RH",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                table: "Responsable_RH",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Responsable_RH",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Responsable_RH",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Responsable_RH",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Responsable_RH",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Responsable_RH",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Responsable_RH",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "key",
                table: "Responsable_RH",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsable_RH",
                table: "Responsable_RH",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsable_RH",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Responsable_RH");

            migrationBuilder.DropColumn(
                name: "key",
                table: "Responsable_RH");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "Responsable_RH",
                newName: "id_resp");

            migrationBuilder.AlterColumn<string>(
                name: "mdp",
                table: "Responsable_RH",
                type: "varchar",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_resp",
                table: "Responsable_RH",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "e_mail",
                table: "Responsable_RH",
                type: "varchar",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsable_RH",
                table: "Responsable_RH",
                column: "id_resp");
        }
    }
}
