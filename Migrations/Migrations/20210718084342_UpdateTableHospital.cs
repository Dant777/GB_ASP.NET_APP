using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class UpdateTableHospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Persons_PersonId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_PersonId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Hospitals");

            migrationBuilder.CreateTable(
                name: "HospitalPerson",
                columns: table => new
                {
                    HospitalsId = table.Column<int>(type: "integer", nullable: false),
                    PersonsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalPerson", x => new { x.HospitalsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_HospitalPerson_Hospitals_HospitalsId",
                        column: x => x.HospitalsId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalPerson_PersonsId",
                table: "HospitalPerson",
                column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalPerson");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Hospitals",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_PersonId",
                table: "Hospitals",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Persons_PersonId",
                table: "Hospitals",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
