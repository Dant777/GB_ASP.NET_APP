using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Migrations.Migrations
{
    public partial class AddClinicsInDBUpdatePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicPerson",
                columns: table => new
                {
                    ClinicsId = table.Column<int>(type: "integer", nullable: false),
                    PersonsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPerson", x => new { x.ClinicsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_ClinicPerson_Clinic_ClinicsId",
                        column: x => x.ClinicsId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPerson_PersonsId",
                table: "ClinicPerson",
                column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicPerson");

            migrationBuilder.DropTable(
                name: "Clinic");
        }
    }
}
