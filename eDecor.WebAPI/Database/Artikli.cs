using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Artikli
    {
        public Artikli()
        {
            Ocjene = new HashSet<Ocjene>();
            RezervacijeArtikli = new HashSet<RezervacijeArtikli>();
        }

        public int ArtikalId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public bool Status { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int KategorijaId { get; set; }
        public int PodkategorijaId { get; set; }

        public virtual Kategorije Kategorija { get; set; }
        public virtual Podkategorije Podkategorija { get; set; }
        public virtual ICollection<Ocjene> Ocjene { get; set; }
        public virtual ICollection<RezervacijeArtikli> RezervacijeArtikli { get; set; }
    }
}
