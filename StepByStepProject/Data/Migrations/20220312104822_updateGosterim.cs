using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStepProject.Data.Migrations
{
    public partial class updateGosterim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Baslangic",
                table: "Gosterimler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Bitis",
                table: "Gosterimler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Baslangic",
                table: "Gosterimler");

            migrationBuilder.DropColumn(
                name: "Bitis",
                table: "Gosterimler");
        }
    }
}
