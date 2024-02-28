using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_add_petnabiz_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "VeterinaryClinics");

            migrationBuilder.DropColumn(
                name: "District",
                table: "VeterinaryClinics");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "VeterinaryClinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "VeterinaryClinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VeterinaryClinics_CityId",
                table: "VeterinaryClinics",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_VeterinaryClinics_DistrictId",
                table: "VeterinaryClinics",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_VeterinaryClinics_Cities_CityId",
                table: "VeterinaryClinics",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_VeterinaryClinics_Districts_DistrictId",
                table: "VeterinaryClinics",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeterinaryClinics_Cities_CityId",
                table: "VeterinaryClinics");

            migrationBuilder.DropForeignKey(
                name: "FK_VeterinaryClinics_Districts_DistrictId",
                table: "VeterinaryClinics");

            migrationBuilder.DropIndex(
                name: "IX_VeterinaryClinics_CityId",
                table: "VeterinaryClinics");

            migrationBuilder.DropIndex(
                name: "IX_VeterinaryClinics_DistrictId",
                table: "VeterinaryClinics");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "VeterinaryClinics");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "VeterinaryClinics");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "VeterinaryClinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "VeterinaryClinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
