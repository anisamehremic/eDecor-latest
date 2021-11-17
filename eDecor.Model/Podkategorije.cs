using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Podkategorije
    {
        public int PodkategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int KategorijaId { get; set; }
        public virtual Kategorije Kategorija { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
