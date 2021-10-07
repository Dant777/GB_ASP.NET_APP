using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class ConfigManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalPerson_Hospitals_HospitalsId",
                table: "HospitalPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalPerson_Persons_PersonsId",
                table: "HospitalPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalPerson",
                table: "HospitalPerson");

            migrationBuilder.RenameTable(
                name: "HospitalPerson",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalPerson_PersonsId",
                table: "Enrollments",
                newName: "IX_Enrollments_PersonsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                columns: new[] { "HospitalsId", "PersonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Hospitals_HospitalsId",
                table: "Enrollments",
                column: "HospitalsId",
                principalTable: "Hospitals",
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
                name: "FK_Enrollments_Hospitals_HospitalsId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Persons_PersonsId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "HospitalPerson");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_PersonsId",
                table: "HospitalPerson",
                newName: "IX_HospitalPerson_PersonsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalPerson",
                table: "HospitalPerson",
                columns: new[] { "HospitalsId", "PersonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalPerson_Hospitals_HospitalsId",
                table: "HospitalPerson",
                column: "HospitalsId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalPerson_Persons_PersonsId",
                table: "HospitalPerson",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
