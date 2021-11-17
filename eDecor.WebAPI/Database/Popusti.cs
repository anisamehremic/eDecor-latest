using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Popusti
    {
        public Popusti()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int PopustId { get; set; }
        public string Kod { get; set; }
        public decimal? Popust { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
