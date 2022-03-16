using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStepProject.Data.Migrations
{
    public partial class DilNameEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Language");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Language",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Language");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Language",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
