using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Podkategorije
    {
        public Podkategorije()
        {
            Artikli = new HashSet<Artikli>();
        }

        public int PodkategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int KategorijaId { get; set; }

        public virtual Kategorije Kategorija { get; set; }
        public virtual ICollection<Artikli> Artikli { get; set; }
    }
}
