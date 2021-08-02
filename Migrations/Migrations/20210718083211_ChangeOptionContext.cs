using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class ChangeOptionContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPerson_Clinics_ClinicsId",
                table: "ClinicPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPerson_Persons_PersonsId",
                table: "ClinicPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicPerson",
                table: "ClinicPerson");

            migrationBuilder.RenameTable(
                name: "ClinicPerson",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_ClinicPerson_PersonsId",
                table: "Enrollments",
                newName: "IX_Enrollments_PersonsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                columns: new[] { "ClinicsId", "PersonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Clinics_ClinicsId",
                table: "Enrollments",
                column: "ClinicsId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Persons_PersonsId",
                table: "Enrollments",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Clinics_ClinicsId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Persons_PersonsId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "ClinicPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_PersonsId",
                table: "ClinicPerson",
                newName: "IX_ClinicPerson_PersonsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicPerson",
                table: "ClinicPerson",
                columns: new[] { "ClinicsId", "PersonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPerson_Clinics_ClinicsId",
                table: "ClinicPerson",
                column: "ClinicsId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPerson_Persons_PersonsId",
                table: "ClinicPerson",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
