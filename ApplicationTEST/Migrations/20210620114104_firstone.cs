using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationTEST.Migrations
{
    public partial class firstone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    nom = table.Column<string>(type: "text", nullable: true),
                    prenom = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    CVname = table.Column<string>(type: "text", nullable: true),
                    CVoriginalfilename = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    etat_matrimonial = table.Column<string>(type: "text", nullable: true),
                    adresse = table.Column<string>(type: "text", nullable: true),
                    metier = table.Column<string>(type: "text", nullable: true),
                    genre = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    key = table.Column<string>(type: "text", nullable: true),
                    mdp = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offre",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    type_offre = table.Column<string>(type: "text", nullable: true),
                    type_contrat = table.Column<string>(type: "text", nullable: true),
                    lieu_travail = table.Column<string>(type: "text", nullable: true),
                    nbr_poste = table.Column<string>(type: "text", nullable: true),
                    annee_exp = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    date_publication = table.Column<string>(type: "text", nullable: true),
                    date_expiration = table.Column<string>(type: "text", nullable: true),
                    niveau_pro = table.Column<string>(type: "text", nullable: true),
                    archiver = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    commentaire = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.id);
                    table.ForeignKey(
                        name: "FK_Commentaire_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Generer",
                columns: table => new
                {
                    id_generer = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    poste_domande = table.Column<string>(type: "varchar", nullable: true),
                    domaine_activite = table.Column<string>(type: "varchar", nullable: true),
                    photo_profil = table.Column<string>(type: "varchar", nullable: true),
                    salaire_min = table.Column<double>(type: "double precision", nullable: false),
                    CandidatId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generer", x => x.id_generer);
                    table.ForeignKey(
                        name: "FK_Generer_AspNetUsers_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hobby = table.Column<string>(type: "text", nullable: true),
                    candidatId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hobbies_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linkedins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    linkedin = table.Column<string>(type: "text", nullable: true),
                    id_candidat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linkedins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Linkedins_AspNetUsers_id_candidat",
                        column: x => x.id_candidat,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etat = table.Column<string>(type: "text", nullable: true),
                    nom = table.Column<string>(type: "text", nullable: true),
                    prenom = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    date_candidature = table.Column<string>(type: "text", nullable: true),
                    lettre_motivation = table.Column<string>(type: "text", nullable: true),
                    salaire_demande = table.Column<string>(type: "text", nullable: true),
                    archiver = table.Column<bool>(type: "boolean", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    offreid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => x.id);
                    table.ForeignKey(
                        name: "FK_Candidature_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidature_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competence",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    niveau = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<int>(type: "integer", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    require = table.Column<bool>(type: "boolean", nullable: false),
                    offreid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competence", x => x.id);
                    table.ForeignKey(
                        name: "FK_Competence_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competence_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diplome",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    require = table.Column<bool>(type: "boolean", nullable: false),
                    offreid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplome", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diplome_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    nbr_questions = table.Column<int>(type: "integer", nullable: false),
                    duree = table.Column<double>(type: "double precision", nullable: false),
                    passed = table.Column<bool>(type: "boolean", nullable: false),
                    id_offre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Examens_Offre_id_offre",
                        column: x => x.id_offre,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    langue = table.Column<string>(type: "text", nullable: true),
                    niveau = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<int>(type: "integer", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    offreid = table.Column<int>(type: "integer", nullable: true),
                    require = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.id);
                    table.ForeignKey(
                        name: "FK_Langues_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Langues_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titre = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    offreid = table.Column<int>(type: "integer", nullable: true),
                    require = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questionnaire_Offre_offreid",
                        column: x => x.offreid,
                        principalTable: "Offre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reponse = table.Column<string>(type: "text", nullable: true),
                    correcte = table.Column<bool>(type: "boolean", nullable: false),
                    questionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reponses_Questions_questionid",
                        column: x => x.questionid,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experience_prof",
                columns: table => new
                {
                    id_ex = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    poste_occupe = table.Column<string>(type: "text", nullable: true),
                    lieu_Exp = table.Column<string>(type: "text", nullable: true),
                    date_debut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    employeur = table.Column<string>(type: "text", nullable: true),
                    date_fin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    typeEmploi = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "varchar", nullable: true),
                    id_generer = table.Column<int>(type: "integer", nullable: true),
                    candidatId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience_prof", x => x.id_ex);
                    table.ForeignKey(
                        name: "FK_Experience_prof_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experience_prof_Generer_id_generer",
                        column: x => x.id_generer,
                        principalTable: "Generer",
                        principalColumn: "id_generer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    diplome = table.Column<string>(type: "varchar", nullable: true),
                    universite = table.Column<string>(type: "varchar", nullable: true),
                    annee_debut = table.Column<string>(type: "text", nullable: true),
                    annee_fin = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    id_generer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Formation_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Formation_Generer_id_generer",
                        column: x => x.id_generer,
                        principalTable: "Generer",
                        principalColumn: "id_generer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note_Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    examenid = table.Column<int>(type: "integer", nullable: true),
                    questionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Note_Questions_Examens_examenid",
                        column: x => x.examenid,
                        principalTable: "Examens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Questions_Questions_questionid",
                        column: x => x.questionid,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results_Examens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_result = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note_totale = table.Column<double>(type: "double precision", nullable: false),
                    passed = table.Column<bool>(type: "boolean", nullable: false),
                    candidatId = table.Column<string>(type: "text", nullable: true),
                    examenid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results_Examens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Examens_AspNetUsers_candidatId",
                        column: x => x.candidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Examens_Examens_examenid",
                        column: x => x.examenid,
                        principalTable: "Examens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_candidatId",
                table: "Candidature",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_offreid",
                table: "Candidature",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_candidatId",
                table: "Commentaire",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_candidatId",
                table: "Competence",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_offreid",
                table: "Competence",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Diplome_offreid",
                table: "Diplome",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Examens_id_offre",
                table: "Examens",
                column: "id_offre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experience_prof_candidatId",
                table: "Experience_prof",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_prof_id_generer",
                table: "Experience_prof",
                column: "id_generer");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_candidatId",
                table: "Formation",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_id_generer",
                table: "Formation",
                column: "id_generer");

            migrationBuilder.CreateIndex(
                name: "IX_Generer_CandidatId",
                table: "Generer",
                column: "CandidatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_candidatId",
                table: "Hobbies",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Langues_candidatId",
                table: "Langues",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Langues_offreid",
                table: "Langues",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Linkedins_id_candidat",
                table: "Linkedins",
                column: "id_candidat",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_Questions_examenid",
                table: "Note_Questions",
                column: "examenid");

            migrationBuilder.CreateIndex(
                name: "IX_Note_Questions_questionid",
                table: "Note_Questions",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaire_offreid",
                table: "Questionnaire",
                column: "offreid");

            migrationBuilder.CreateIndex(
                name: "IX_Reponses_questionid",
                table: "Reponses",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Examens_candidatId",
                table: "Results_Examens",
                column: "candidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Examens_examenid",
                table: "Results_Examens",
                column: "examenid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Commentaire");

            migrationBuilder.DropTable(
                name: "Competence");

            migrationBuilder.DropTable(
                name: "Diplome");

            migrationBuilder.DropTable(
                name: "Experience_prof");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Langues");

            migrationBuilder.DropTable(
                name: "Linkedins");

            migrationBuilder.DropTable(
                name: "Note_Questions");

            migrationBuilder.DropTable(
                name: "Questionnaire");

            migrationBuilder.DropTable(
                name: "Reponses");

            migrationBuilder.DropTable(
                name: "Results_Examens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Generer");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Examens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Offre");
        }
    }
}
