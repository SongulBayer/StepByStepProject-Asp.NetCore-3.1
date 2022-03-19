using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStepProject.Data.Migrations
{
    public partial class GosterimlerDuzenlendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Film_FilmId",
                table: "Gosterimler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Salon_SalonId",
                table: "Gosterimler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Sinema_SinemaId",
                table: "Gosterimler");

            migrationBuilder.AlterColumn<int>(
                name: "SinemaId",
                table: "Gosterimler",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Gosterimler",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Gosterimler",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Film_FilmId",
                table: "Gosterimler",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Salon_SalonId",
                table: "Gosterimler",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Sinema_SinemaId",
                table: "Gosterimler",
                column: "SinemaId",
                principalTable: "Sinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Film_FilmId",
                table: "Gosterimler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Salon_SalonId",
                table: "Gosterimler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gosterimler_Sinema_SinemaId",
                table: "Gosterimler");

            migrationBuilder.AlterColumn<int>(
                name: "SinemaId",
                table: "Gosterimler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Gosterimler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Gosterimler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Film_FilmId",
                table: "Gosterimler",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Salon_SalonId",
                table: "Gosterimler",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gosterimler_Sinema_SinemaId",
                table: "Gosterimler",
                column: "SinemaId",
                principalTable: "Sinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
