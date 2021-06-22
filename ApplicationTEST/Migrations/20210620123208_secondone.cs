using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationTEST.Migrations
{
    public partial class secondone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Results_Examens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Langues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Hobbies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Formation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Experience_prof",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Competence",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Commentaire",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsable_RHId",
                table: "Candidature",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_naissance",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genererid_generer",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "linkedinid",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Results_Examens_Responsable_RHId",
                table: "Results_Examens",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Langues_Responsable_RHId",
                table: "Langues",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_Responsable_RHId",
                table: "Hobbies",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_Responsable_RHId",
                table: "Formation",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_prof_Responsable_RHId",
                table: "Experience_prof",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Responsable_RHId",
                table: "Competence",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_Responsable_RHId",
                table: "Commentaire",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_Responsable_RHId",
                table: "Candidature",
                column: "Responsable_RHId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_genererid_generer",
                table: "AspNetUsers",
                column: "genererid_generer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_linkedinid",
                table: "AspNetUsers",
                column: "linkedinid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Generer_genererid_generer",
                table: "AspNetUsers",
                column: "genererid_generer",
                principalTable: "Generer",
                principalColumn: "id_generer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Linkedins_linkedinid",
                table: "AspNetUsers",
                column: "linkedinid",
                principalTable: "Linkedins",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidature_AspNetUsers_Responsable_RHId",
                table: "Candidature",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaire_AspNetUsers_Responsable_RHId",
                table: "Commentaire",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Competence_AspNetUsers_Responsable_RHId",
                table: "Competence",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_prof_AspNetUsers_Responsable_RHId",
                table: "Experience_prof",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_AspNetUsers_Responsable_RHId",
                table: "Formation",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_AspNetUsers_Responsable_RHId",
                table: "Hobbies",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Langues_AspNetUsers_Responsable_RHId",
                table: "Langues",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Examens_AspNetUsers_Responsable_RHId",
                table: "Results_Examens",
                column: "Responsable_RHId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Generer_genererid_generer",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Linkedins_linkedinid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidature_AspNetUsers_Responsable_RHId",
                table: "Candidature");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaire_AspNetUsers_Responsable_RHId",
                table: "Commentaire");

            migrationBuilder.DropForeignKey(
                name: "FK_Competence_AspNetUsers_Responsable_RHId",
                table: "Competence");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_prof_AspNetUsers_Responsable_RHId",
                table: "Experience_prof");

            migrationBuilder.DropForeignKey(
                name: "FK_Formation_AspNetUsers_Responsable_RHId",
                table: "Formation");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_AspNetUsers_Responsable_RHId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Langues_AspNetUsers_Responsable_RHId",
                table: "Langues");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Examens_AspNetUsers_Responsable_RHId",
                table: "Results_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Results_Examens_Responsable_RHId",
                table: "Results_Examens");

            migrationBuilder.DropIndex(
                name: "IX_Langues_Responsable_RHId",
                table: "Langues");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_Responsable_RHId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_Formation_Responsable_RHId",
                table: "Formation");

            migrationBuilder.DropIndex(
                name: "IX_Experience_prof_Responsable_RHId",
                table: "Experience_prof");

            migrationBuilder.DropIndex(
                name: "IX_Competence_Responsable_RHId",
                table: "Competence");

            migrationBuilder.DropIndex(
                name: "IX_Commentaire_Responsable_RHId",
                table: "Commentaire");

            migrationBuilder.DropIndex(
                name: "IX_Candidature_Responsable_RHId",
                table: "Candidature");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_genererid_generer",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_linkedinid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Results_Examens");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Langues");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Formation");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Experience_prof");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Competence");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Commentaire");

            migrationBuilder.DropColumn(
                name: "Responsable_RHId",
                table: "Candidature");

            migrationBuilder.DropColumn(
                name: "genererid_generer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "linkedinid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_naissance",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
