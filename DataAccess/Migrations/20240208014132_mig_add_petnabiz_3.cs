using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_add_petnabiz_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_VeterinaryClinics_VeterinaryClinicId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vets_VeterinaryClinics_VeterinaryClinicId",
                table: "Vets");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Vets");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "Vets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_VeterinaryClinics_VeterinaryClinicId",
                table: "Appointments",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vets_VeterinaryClinics_VeterinaryClinicId",
                table: "Vets",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_VeterinaryClinics_VeterinaryClinicId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vets_VeterinaryClinics_VeterinaryClinicId",
                table: "Vets");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "Vets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Vets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinaryClinicId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_VeterinaryClinics_VeterinaryClinicId",
                table: "Appointments",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VeterinaryClinics_VeterinaryClinicId",
                table: "AspNetUsers",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vets_VeterinaryClinics_VeterinaryClinicId",
                table: "Vets",
                column: "VeterinaryClinicId",
                principalTable: "VeterinaryClinics",
                principalColumn: "Id");
        }
    }
}
