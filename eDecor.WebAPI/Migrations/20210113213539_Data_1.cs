using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDecor.WebAPI.Migrations
{
    public partial class Data_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drzave",
                columns: new[] { "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Srbija" },
                    { 3, "Hrvatska" },
                    { 4, "Crna Gora" },
                    { 5, "Slovenija" },
                    { 6, "Sjeverna Makedonija" }
                });

            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "KategorijaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Vjenčanice", null },
                    { 2, "Buketi", null },
                    { 3, "Cvjetići", null }
                });

            migrationBuilder.InsertData(
                table: "Popusti",
                columns: new[] { "PopustID", "Datum", "Kod", "Popust", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), "1111", 1m, true },
                    { 2, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), "2222", 2m, true },
                    { 3, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), "3333", 3m, true },
                    { 4, new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local), "4444", 4m, true }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Administrator", "Administrator" },
                    { 2, "Radnik", "Radnik u poslovnici" }
                });

            migrationBuilder.InsertData(
                table: "Gradovi",
                columns: new[] { "GradID", "DrzavaID", "Naziv" },
                values: new object[,]
                {
                    { 1, 1, "Mostar" },
                    { 14, 6, "Skoplje" },
                    { 13, 5, "Ljubljana" },
                    { 11, 3, "Dubrovnik" },
                    { 10, 3, "Split" },
                    { 9, 3, "Zagreb" },
                    { 8, 2, "Novi Pazar" },
                    { 12, 4, "Podgorica" },
                    { 6, 2, "Beograd" },
                    { 5, 1, "Tuzla" },
                    { 4, 1, "Banja Luka" },
                    { 3, 1, "Zenica" },
                    { 2, 1, "Sarajevo" },
                    { 7, 2, "Novi Sad" }
                });

            migrationBuilder.InsertData(
                table: "Podkategorije",
                columns: new[] { "PodkategorijaID", "KategorijaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 8, 3, "Saten", null },
                    { 1, 1, "La sposa", null },
                    { 2, 1, "Demetrios", null },
                    { 3, 1, "Promovias", null },
                    { 4, 2, "Bozur", null },
                    { 5, 2, "Orhideja", null },
                    { 6, 2, "Ruža", null },
                    { 7, 3, "Kala", null },
                    { 9, 3, "Juta", null }
                });

            migrationBuilder.InsertData(
                table: "Klijenti",
                columns: new[] { "KlijentID", "DatumRegistracije", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Status", "Telefon" },
                values: new object[] { 1, new DateTime(2020, 11, 21, 10, 10, 26, 966, DateTimeKind.Local), "kupac@gamil.ba", 1, "Kupac", "mobile", "HzoOkNHGE27Bfhd/8f1uxeQRCOM=", "rHh+zm55r5AYhYbSovWIwA==", "Kupac", true, "+387 61 222 222" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Status", "Telefon" },
                values: new object[] { 1, "admin@gmail.ba", 1, "Admin", "desktop", "HzoOkNHGE27Bfhd/8f1uxeQRCOM=", "rHh+zm55r5AYhYbSovWIwA==", "Admin", true, "+387 61 000 000" });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "GradID", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Status", "Telefon" },
                values: new object[] { 2, "radnik@gmail.ba", 1, "Radnik", "radnik", "HzoOkNHGE27Bfhd/8f1uxeQRCOM=", "rHh+zm55r5AYhYbSovWIwA==", "Radnik", true, "+387 61 111 1111" });

            migrationBuilder.InsertData(
                table: "Notifikacije",
                columns: new[] { "NotifikacijaID", "DatumSlanja", "KlijentID", "KorisnikID", "Naziv", "Sadrzaj", "Slika", "Status" },
                values: new object[] { 1, new DateTime(2020, 6, 1, 10, 10, 10, 966, DateTimeKind.Local), 1, 1, "Nova kolekcija ljeto 2020", "U ponudi se sada nalazi nova kolekcija ljeto 2020 ", null, true });

            migrationBuilder.InsertData(
                table: "Notifikacije",
                columns: new[] { "NotifikacijaID", "DatumSlanja", "KlijentID", "KorisnikID", "Naziv", "Sadrzaj", "Slika", "Status" },
                values: new object[] { 2, new DateTime(2021, 1, 13, 10, 10, 10, 966, DateTimeKind.Local), 1, 1, "Nova kolekcija zima 2020/2021", "U ponudi se sada nalazi nova kolekcija zima 2020/2020 ", null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifikacije",
                keyColumn: "NotifikacijaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifikacije",
                keyColumn: "NotifikacijaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Podkategorije",
                keyColumn: "PodkategorijaID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Popusti",
                keyColumn: "PopustID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Popusti",
                keyColumn: "PopustID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Popusti",
                keyColumn: "PopustID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Popusti",
                keyColumn: "PopustID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "KategorijaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "KategorijaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategorije",
                keyColumn: "KategorijaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klijenti",
                keyColumn: "KlijentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gradovi",
                keyColumn: "GradID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drzave",
                keyColumn: "DrzavaID",
                keyValue: 1);
        }
    }
}
