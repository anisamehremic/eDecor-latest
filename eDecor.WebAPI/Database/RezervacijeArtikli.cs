using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class RezervacijeArtikli
    {
        public int RezervacijaArtikalId { get; set; }
        public int ArtikalId { get; set; }
        public int RezervacijaId { get; set; }
        public int Kolicina { get; set; }
        public bool Status { get; set; }

        public virtual Artikli Artikal { get; set; }
        public virtual Rezervacije Rezervacija { get; set; }
    }
}
