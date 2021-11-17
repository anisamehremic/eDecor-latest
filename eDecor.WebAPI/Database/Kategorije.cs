using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Kategorije
    {
        public Kategorije()
        {
            Artikli = new HashSet<Artikli>();
            Podkategorije = new HashSet<Podkategorije>();
            Pretplate = new HashSet<Pretplate>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Artikli> Artikli { get; set; }
        public virtual ICollection<Podkategorije> Podkategorije { get; set; }
        public virtual ICollection<Pretplate> Pretplate { get; set; }
    }
}
