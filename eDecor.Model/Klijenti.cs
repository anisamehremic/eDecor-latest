using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Klijenti
    {
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int GradId { get; set; }
        public string KorisnickoIme { get; set; }
        public bool Status { get; set; }

        public virtual Gradovi Grad { get; set; }

        public override string ToString()
        {
            return $"{KorisnickoIme} ({Ime} {Prezime})";
        }
    }
}
