using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Notifikacije
    {
        public int NotifikacijaId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }
        public bool Status { get; set; }
        public int KorisnikId { get; set; }
        public int? KlijentId { get; set; }

        public string StringStatus { get { return Status ? "Da" : "Ne"; } }

        public virtual Klijenti Klijent { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }
}
