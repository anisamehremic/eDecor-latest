using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
            Notifikacije = new HashSet<Notifikacije>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        public virtual Gradovi Grad { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual ICollection<Notifikacije> Notifikacije { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
