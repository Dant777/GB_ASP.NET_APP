using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class AddClinicsInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPerson_Clinic_ClinicsId",
                table: "ClinicPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic");

            migrationBuilder.RenameTable(
                name: "Clinic",
                newName: "Clinics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPerson_Clinics_ClinicsId",
                table: "ClinicPerson",
                column: "ClinicsId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicPerson_Clinics_ClinicsId",
                table: "ClinicPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicPerson_Clinic_ClinicsId",
                table: "ClinicPerson",
                column: "ClinicsId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
