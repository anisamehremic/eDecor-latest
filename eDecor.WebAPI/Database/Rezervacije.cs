using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Rezervacije
    {
        public Rezervacije()
        {
            RezervacijeArtikli = new HashSet<RezervacijeArtikli>();
        }

        public int RezervacijaId { get; set; }
        public int? KlijentId { get; set; }
        public int? KorisnikId { get; set; }
        public int? PopustId { get; set; }
        public int GradId { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Napomena { get; set; }
        public bool Status { get; set; }
        public bool Placeno { get; set; }
        public decimal IznosAvansnogPlacanje { get; set; }

        public virtual Gradovi Grad { get; set; }
        public virtual Klijenti Klijent { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual Popusti Popust { get; set; }
        public virtual ICollection<RezervacijeArtikli> RezervacijeArtikli { get; set; }
    }
}
