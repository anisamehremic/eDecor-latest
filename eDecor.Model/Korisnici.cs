using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public bool Status { get; set; }

        public virtual Gradovi Grad { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public string Uloge { get; set; }

        public override string ToString()
        {
            return $"{KorisnickoIme} ({Ime} {Prezime})";
        }
    }
}
