using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Klijenti = new HashSet<Klijenti>();
            Korisnici = new HashSet<Korisnici>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; }
        public virtual ICollection<Klijenti> Klijenti { get; set; }
        public virtual ICollection<Korisnici> Korisnici { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
