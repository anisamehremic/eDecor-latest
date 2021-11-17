using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDecor.WebAPI.Migrations
{
    public partial class Data_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artikli",
                columns: new[] { "ArtikalID", "Cijena", "KategorijaID", "Naziv", "Opis", "PodkategorijaID", "Slika", "SlikaThumb", "Status" },
                values: new object[,]
                {
                    { 1, 500m, 1, "Vjenčanica La sposa #1", "Test1", 1, null, null, true },
                    { 2, 550m, 1, "Vjenčanica La sposa #2", "Test1", 1, null, null, true },
                    { 3, 450m, 1, "Vjenčanica Demetrios #1", "Test1", 2, null, null, true },
                    { 4, 400m, 1, "Vjenčanica Promovias #1", "Test1", 3, null, null, true },
                    { 5, 90m, 2, "Buket Bozur #1", "Test1", 4, null, null, true },
                    { 6, 100m, 2, "Buket Orhideja #1", "Test1", 5, null, null, true },
                    { 7, 150m, 2, "Buket Ruza #1", "Test1", 6, null, null, true },
                    { 8, 125m, 2, "Buket Ruza #2", "Test1", 6, null, null, true },
                    { 9, 12m, 3, "Cvjetići Kala #1", "Cvjetići od kale - 50kom", 7, null, null, true },
                    { 10, 9m, 3, "Cvjetići Saten #1", "Cvjetići od satena - 50kom", 8, null, null, true },
                    { 11, 18m, 3, "Cvjetići Saten #2", "Cvjetići od satena - 100kom", 8, null, null, true },
                    { 12, 20m, 3, "Cvjetići Juta #1", "Cvjetići od jute - 50kom", 9, null, null, true }
                });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Artikli",
                keyColumn: "ArtikalID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2);
        }
    }
}
