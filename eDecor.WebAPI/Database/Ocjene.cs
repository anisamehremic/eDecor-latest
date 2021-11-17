using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Ocjene
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
