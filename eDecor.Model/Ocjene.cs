using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Ocjene
    {
        public int OcjenaId { get; set; }
        public int ArtikalId { get; set; }
        public int KlijentId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }

        public virtual Artikli Artikal { get; set; }
        public virtual Klijenti Klijent { get; set; }
    }
}
