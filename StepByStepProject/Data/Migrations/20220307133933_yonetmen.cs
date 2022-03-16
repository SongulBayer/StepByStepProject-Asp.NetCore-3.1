using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStepProject.Data.Migrations
{
    public partial class yonetmen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sira",
                table: "YonetmenFılm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "YonetmenTip",
                table: "YonetmenFılm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "FilmAktors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sira",
                table: "YonetmenFılm");

            migrationBuilder.DropColumn(
                name: "YonetmenTip",
                table: "YonetmenFılm");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "FilmAktors");
        }
    }
}
