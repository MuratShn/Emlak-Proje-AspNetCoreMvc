using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmlakOfis.Migrations
{
    public partial class mg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyısım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emlakcis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emlakcis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kategoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sehirs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehirs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "evs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metrekare = table.Column<int>(type: "int", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Katsayi = table.Column<int>(type: "int", nullable: false),
                    OdaSayi = table.Column<int>(type: "int", nullable: false),
                    SalonSayi = table.Column<int>(type: "int", nullable: false),
                    Acıklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    EmlakciId = table.Column<int>(type: "int", nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evs_emlakcis_EmlakciId",
                        column: x => x.EmlakciId,
                        principalTable: "emlakcis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evs_kategoris_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "kategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evs_sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "sehirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evs_EmlakciId",
                table: "evs",
                column: "EmlakciId");

            migrationBuilder.CreateIndex(
                name: "IX_evs_KategoriId",
                table: "evs",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_evs_SehirId",
                table: "evs",
                column: "SehirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "evs");

            migrationBuilder.DropTable(
                name: "emlakcis");

            migrationBuilder.DropTable(
                name: "kategoris");

            migrationBuilder.DropTable(
                name: "sehirs");
        }
    }
}
