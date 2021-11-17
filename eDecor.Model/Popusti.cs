using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Popusti
    {
        public int PopustId { get; set; }
        public string Kod { get; set; }
        public decimal? Popust { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public string StringStatus { get { return Status ? "Da" : "Ne"; } }

        public override string ToString()
        {
            return Popust + " %";
        }
    }
}
