using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class RezervacijeArtikli
    {
        public int RezervacijaArtikalId { get; set; }
        public int ArtikalId { get; set; }
        public int RezervacijaId { get; set; }
        public int Kolicina { get; set; }
        public bool Status { get; set; }

        public virtual Artikli Artikal { get; set; }
    }
}
