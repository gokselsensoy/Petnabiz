using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_add_petnabiz_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
