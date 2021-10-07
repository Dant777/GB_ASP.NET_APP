using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Migrations.Migrations
{
    public partial class addCardinDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientCardId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HospitalId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientCards_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PatientCardId",
                table: "Persons",
                column: "PatientCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCards_HospitalId",
                table: "PatientCards",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PatientCards_PatientCardId",
                table: "Persons",
                column: "PatientCardId",
                principalTable: "PatientCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PatientCards_PatientCardId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PatientCards");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PatientCardId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PatientCardId",
                table: "Persons");
        }
    }
}
