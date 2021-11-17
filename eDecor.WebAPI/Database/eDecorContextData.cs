using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eDecor.WebAPI.Database
{
    public partial class eDecorContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Kad god dodamo polje uvijek radimo Add-Migration Data...

            //Drzave
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 1,
                Naziv = "Bosna i Hercegovina"
            });
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 2,
                Naziv = "Srbija"
            });
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 3,
                Naziv = "Hrvatska"
            });
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 4,
                Naziv = "Crna Gora"
            });
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 5,
                Naziv = "Slovenija"
            });
            modelBuilder.Entity<Drzave>().HasData(new eDecor.WebAPI.Database.Drzave()
            {
                DrzavaId = 6,
                Naziv = "Sjeverna Makedonija"
            });

            //Gradovi
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 1,
                Naziv = "Mostar",
                DrzavaId = 1
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 2,
                Naziv = "Sarajevo",
                DrzavaId = 1
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 3,
                Naziv = "Zenica",
                DrzavaId = 1
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 4,
                Naziv = "Banja Luka",
                DrzavaId = 1
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 5,
                Naziv = "Tuzla",
                DrzavaId = 1
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 6,
                Naziv = "Beograd",
                DrzavaId = 2
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 7,
                Naziv = "Novi Sad",
                DrzavaId = 2
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 8,
                Naziv = "Novi Pazar",
                DrzavaId = 2
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 9,
                Naziv = "Zagreb",
                DrzavaId = 3
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 10,
                Naziv = "Split",
                DrzavaId = 3
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 11,
                Naziv = "Dubrovnik",
                DrzavaId = 3
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 12,
                Naziv = "Podgorica",
                DrzavaId = 4
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 13,
                Naziv = "Ljubljana",
                DrzavaId = 5
            });
            modelBuilder.Entity<Gradovi>().HasData(new eDecor.WebAPI.Database.Gradovi()
            {
                GradId = 14,
                Naziv = "Skoplje",
                DrzavaId = 6
            });

            //Kategorije
            modelBuilder.Entity<Kategorije>().HasData(new eDecor.WebAPI.Database.Kategorije()
            {
                KategorijaId = 1,
                Naziv = "Vjenčanice"
            });
            modelBuilder.Entity<Kategorije>().HasData(new eDecor.WebAPI.Database.Kategorije()
            {
                KategorijaId = 2,
                Naziv = "Buketi"
            });
            modelBuilder.Entity<Kategorije>().HasData(new eDecor.WebAPI.Database.Kategorije()
            {
                KategorijaId = 3,
                Naziv = "Cvjetići",
            });

            //Podkategorije
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 1,
                KategorijaId = 1,
                Naziv = "La sposa"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 2,
                KategorijaId = 1,
                Naziv = "Demetrios"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 3,
                KategorijaId = 1,
                Naziv = "Promovias"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 4,
                KategorijaId = 2,
                Naziv = "Bozur"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 5,
                KategorijaId = 2,
                Naziv = "Orhideja"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 6,
                KategorijaId = 2,
                Naziv = "Ruža"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 7,
                KategorijaId = 3,
                Naziv = "Kala"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 8,
                KategorijaId = 3,
                Naziv = "Saten"
            });
            modelBuilder.Entity<Podkategorije>().HasData(new eDecor.WebAPI.Database.Podkategorije()
            {
                PodkategorijaId = 9,
                KategorijaId = 3,
                Naziv = "Juta"
            });

            //Popusti
            modelBuilder.Entity<Popusti>().HasData(new eDecor.WebAPI.Database.Popusti()
            {
                PopustId = 1,
                Kod = "1111",
                Popust = 1,
                Datum = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                Status = true
            });
            modelBuilder.Entity<Popusti>().HasData(new eDecor.WebAPI.Database.Popusti()
            {
                PopustId = 2,
                Kod = "2222",
                Popust = 2,
                Datum = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                Status = true
            });
            modelBuilder.Entity<Popusti>().HasData(new eDecor.WebAPI.Database.Popusti()
            {
                PopustId = 3,
                Kod = "3333",
                Popust = 3,
                Datum = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                Status = true
            });
            modelBuilder.Entity<Popusti>().HasData(new eDecor.WebAPI.Database.Popusti()
            {
                PopustId = 4,
                Kod = "4444",
                Popust = 4,
                Datum = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                Status = true
            });

            //Artikli
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 1,
                Naziv = "Vjenčanica La sposa #1",
                Opis = "Test1",
                Cijena = 500,
                Status = true,
                KategorijaId = 1,
                PodkategorijaId = 1
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 2,
                Naziv = "Vjenčanica La sposa #2",
                Opis = "Test1",
                Cijena = 550,
                Status = true,
                KategorijaId = 1,
                PodkategorijaId = 1
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 3,
                Naziv = "Vjenčanica Demetrios #1",
                Opis = "Test1",
                Cijena = 450,
                Status = true,
                KategorijaId = 1,
                PodkategorijaId = 2
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 4,
                Naziv = "Vjenčanica Promovias #1",
                Opis = "Test1",
                Cijena = 400,
                Status = true,
                KategorijaId = 1,
                PodkategorijaId = 3
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 5,
                Naziv = "Buket Bozur #1",
                Opis = "Test1",
                Cijena = 90,
                Status = true,
                KategorijaId = 2,
                PodkategorijaId = 4
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 6,
                Naziv = "Buket Orhideja #1",
                Opis = "Test1",
                Cijena = 100,
                Status = true,
                KategorijaId = 2,
                PodkategorijaId = 5
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 7,
                Naziv = "Buket Ruza #1",
                Opis = "Test1",
                Cijena = 150,
                Status = true,
                KategorijaId = 2,
                PodkategorijaId = 6
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 8,
                Naziv = "Buket Ruza #2",
                Opis = "Test1",
                Cijena = 125,
                Status = true,
                KategorijaId = 2,
                PodkategorijaId = 6
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 9,
                Naziv = "Cvjetići Kala #1",
                Opis = "Cvjetići od kale - 50kom",
                Cijena = 12,
                Status = true,
                KategorijaId = 3,
                PodkategorijaId = 7
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 10,
                Naziv = "Cvjetići Saten #1",
                Opis = "Cvjetići od satena - 50kom",
                Cijena = 9,
                Status = true,
                KategorijaId = 3,
                PodkategorijaId = 8
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 11,
                Naziv = "Cvjetići Saten #2",
                Opis = "Cvjetići od satena - 100kom",
                Cijena = 18,
                Status = true,
                KategorijaId = 3,
                PodkategorijaId = 8
            });
            modelBuilder.Entity<Artikli>().HasData(new eDecor.WebAPI.Database.Artikli()
            {
                ArtikalId = 12,
                Naziv = "Cvjetići Juta #1",
                Opis = "Cvjetići od jute - 50kom",
                Cijena = 20,
                Status = true,
                KategorijaId = 3,
                PodkategorijaId = 9
            });

            //Uloge
            modelBuilder.Entity<Uloge>().HasData(new eDecor.WebAPI.Database.Uloge()
            {
                UlogaId = 1,
                Naziv = "Administrator",
                Opis = "Administrator"
            });
            modelBuilder.Entity<Uloge>().HasData(new eDecor.WebAPI.Database.Uloge()
            {
                UlogaId = 2,
                Naziv = "Radnik",
                Opis = "Radnik u poslovnici"
            });

            //Korisnici
            modelBuilder.Entity<Korisnici>().HasData(new eDecor.WebAPI.Database.Korisnici()
            {
                KorisnikId = 1,
                Ime = "Admin",
                Prezime = "Admin",
                Email = "admin@gmail.ba",
                GradId = 1,
                Telefon = "+387 61 000 000",
                KorisnickoIme = "desktop",
                LozinkaHash = "HzoOkNHGE27Bfhd/8f1uxeQRCOM=",
                LozinkaSalt = "rHh+zm55r5AYhYbSovWIwA==",
                Status = true
            });
            modelBuilder.Entity<Korisnici>().HasData(new eDecor.WebAPI.Database.Korisnici()
            {
                KorisnikId = 2,
                Ime = "Radnik",
                Prezime = "Radnik",
                Email = "radnik@gmail.ba",
                GradId = 1,
                Telefon = "+387 61 111 1111",
                KorisnickoIme = "radnik",
                LozinkaHash = "HzoOkNHGE27Bfhd/8f1uxeQRCOM=",
                LozinkaSalt = "rHh+zm55r5AYhYbSovWIwA==",
                Status = true
            });

            //Klijent
            modelBuilder.Entity<Klijenti>().HasData(new eDecor.WebAPI.Database.Klijenti()
            {
                KlijentId = 1,
                Ime = "Kupac",
                Prezime = "Kupac",
                Email = "kupac@gamil.ba",
                GradId = 1,
                Telefon = "+387 61 222 222",
                KorisnickoIme = "mobile",
                LozinkaHash = "HzoOkNHGE27Bfhd/8f1uxeQRCOM=",
                LozinkaSalt = "rHh+zm55r5AYhYbSovWIwA==",
                Status = true,
                DatumRegistracije = new DateTime(2020, 11, 21, 10, 10, 26, 966, DateTimeKind.Local)
            });

            //Notifikacije
            modelBuilder.Entity<Notifikacije>().HasData(new eDecor.WebAPI.Database.Notifikacije()
            {
                NotifikacijaId = 1,
                DatumSlanja = new DateTime(2020, 6, 1, 10, 10, 10, 966, DateTimeKind.Local),
                Naziv = "Nova kolekcija ljeto 2020",
                Sadrzaj = "U ponudi se sada nalazi nova kolekcija ljeto 2020 ",
                Status = true,
                KorisnikId = 1, 
                KlijentId = 1
            });
            modelBuilder.Entity<Notifikacije>().HasData(new eDecor.WebAPI.Database.Notifikacije()
            {
                NotifikacijaId = 2,
                DatumSlanja = new DateTime(2021, 1, 13, 10, 10, 10, 966, DateTimeKind.Local),
                Naziv = "Nova kolekcija zima 2020/2021",
                Sadrzaj = "U ponudi se sada nalazi nova kolekcija zima 2020/2020 ",
                Status = true,
                KorisnikId = 1,
                KlijentId = 1
            });

            //KorisniciUloge
            modelBuilder.Entity<KorisniciUloge>().HasData(new eDecor.WebAPI.Database.KorisniciUloge()
            {
                KorisnikUlogaId = 1,
                DatumIzmjene = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                KorisnikId = 1,
                UlogaId = 1
            });
            modelBuilder.Entity<KorisniciUloge>().HasData(new eDecor.WebAPI.Database.KorisniciUloge()
            {
                KorisnikUlogaId = 2,
                DatumIzmjene = new DateTime(2020, 11, 21, 10, 10, 10, 966, DateTimeKind.Local),
                KorisnikId = 2,
                UlogaId = 2
            });
        }
    }
}
