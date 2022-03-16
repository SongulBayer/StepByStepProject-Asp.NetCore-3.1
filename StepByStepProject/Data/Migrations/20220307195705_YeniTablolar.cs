using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepByStepProject.Data.Migrations
{
    public partial class YeniTablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Il",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IlAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Il", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IlceAd = table.Column<string>(nullable: true),
                    IlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilce_Il_IlId",
                        column: x => x.IlId,
                        principalTable: "Il",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinemaAd = table.Column<string>(nullable: true),
                    IlceId = table.Column<int>(nullable: true),
                    Iletisim = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinema_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonAd = table.Column<string>(nullable: true),
                    SinemaId = table.Column<int>(nullable: true),
                    Kapasite = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salon_Sinema_SinemaId",
                        column: x => x.SinemaId,
                        principalTable: "Sinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gosterimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    SalonId = table.Column<int>(nullable: false),
                    AltYazi = table.Column<bool>(nullable: true),
                    SinemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gosterimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gosterimler_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gosterimler_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gosterimler_Sinema_SinemaId",
                        column: x => x.SinemaId,
                        principalTable: "Sinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GosterimlerId = table.Column<int>(nullable: true),
                    GosterimId = table.Column<int>(nullable: false),
                    SeansBaslangic = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seans_Gosterimler_GosterimlerId",
                        column: x => x.GosterimlerId,
                        principalTable: "Gosterimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeansId = table.Column<int>(nullable: false),
                    AlisZamani = table.Column<DateTime>(nullable: false),
                    Ucret = table.Column<double>(nullable: false),
                    Adet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilet_Seans_SeansId",
                        column: x => x.SeansId,
                        principalTable: "Seans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Koltuklar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiletId = table.Column<int>(nullable: false),
                    KoltukSira = table.Column<string>(nullable: true),
                    KoltukSutun = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koltuklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koltuklar_Bilet_BiletId",
                        column: x => x.BiletId,
                        principalTable: "Bilet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_SeansId",
                table: "Bilet",
                column: "SeansId");

            migrationBuilder.CreateIndex(
                name: "IX_Gosterimler_FilmId",
                table: "Gosterimler",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Gosterimler_SalonId",
                table: "Gosterimler",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Gosterimler_SinemaId",
                table: "Gosterimler",
                column: "SinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_IlId",
                table: "Ilce",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklar_BiletId",
                table: "Koltuklar",
                column: "BiletId");

            migrationBuilder.CreateIndex(
                name: "IX_Salon_SinemaId",
                table: "Salon",
                column: "SinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seans_GosterimlerId",
                table: "Seans",
                column: "GosterimlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinema_IlceId",
                table: "Sinema",
                column: "IlceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koltuklar");

            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Seans");

            migrationBuilder.DropTable(
                name: "Gosterimler");

            migrationBuilder.DropTable(
                name: "Salon");

            migrationBuilder.DropTable(
                name: "Sinema");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Il");
        }
    }
}
