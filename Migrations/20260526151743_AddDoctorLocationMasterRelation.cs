using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEDICINE.WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorLocationMasterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CityId",
                table: "Doctors",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CountryId",
                table: "Doctors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_StateId",
                table: "Doctors",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cities_CityId",
                table: "Doctors",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Countries_CountryId",
                table: "Doctors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_States_StateId",
                table: "Doctors",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cities_CityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Countries_CountryId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_States_StateId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CityId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CountryId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_StateId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Doctors");
        }
    }
}
