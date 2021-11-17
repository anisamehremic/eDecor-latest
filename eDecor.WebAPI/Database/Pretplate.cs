using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Pretplate
    {
        public int PretplataId { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public int KlijentId { get; set; }
        public int KategorijaId { get; set; }

        public virtual Kategorije Kategorija { get; set; }
        public virtual Klijenti Klijent { get; set; }
    }
}
