using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Kategorije
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
