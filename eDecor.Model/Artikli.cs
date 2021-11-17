using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Artikli
    {
        public int ArtikalId { get; set; }
        public decimal Cijena { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool Status { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int KategorijaId { get; set; }
        public int PodkategorijaId { get; set; }

        public virtual Kategorije Kategorija { get; set; }
        public virtual Podkategorije Podkategorija { get; set; }

        public int Kolicina { get; set; }//samo za prikaz 

        public override string ToString()
        {
            return $"{Naziv} ({Cijena} KM)";
        }
    }
}
