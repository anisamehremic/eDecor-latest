using System;
using System.Collections.Generic;

namespace eDecor.WebAPI.Database
{
    public partial class Notifikacije
    {
        public int NotifikacijaId { get; set; }
        public DateTime DatumSlanja { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }
        public bool Status { get; set; }
        public int KorisnikId { get; set; }
        public int? KlijentId { get; set; }

        public virtual Klijenti Klijent { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }
}
