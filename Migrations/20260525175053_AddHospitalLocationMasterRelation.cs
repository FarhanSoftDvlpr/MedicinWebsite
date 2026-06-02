using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEDICINE.WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddHospitalLocationMasterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_CityId",
                table: "Hospitals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_CountryId",
                table: "Hospitals",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_StateId",
                table: "Hospitals",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_CityId",
                table: "Hospitals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Countries_CountryId",
                table: "Hospitals",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_States_StateId",
                table: "Hospitals",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_CityId",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Countries_CountryId",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_States_StateId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_CityId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_CountryId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_StateId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Hospitals");
        }
    }
}
