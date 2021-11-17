using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Pretplate
    {
        public int PretplataId { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public int KlijentId { get; set; }
        public int KategorijaId { get; set; }
        public string StringStatus { get { return Status ? "Da" : "Ne"; } }
        public virtual Kategorije Kategorija { get; set; }
        public virtual Klijenti Klijent { get; set; }
    }
}
