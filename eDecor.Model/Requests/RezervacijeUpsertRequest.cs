using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class RezervacijeUpsertRequest
    {
        public int? KlijentId { get; set; }
        public int? KorisnikId { get; set; }
        public int? PopustId { get; set; }
        [Required]
        public int GradId { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public DateTime DatumKreiranja { get; set; }
        public string Napomena { get; set; }
        [Required]
        public bool Status { get; set; }
        public bool Placeno { get; set; }
        public decimal IznosAvansnogPlacanje { get; set; }

        public List<RezervacijeArtikli> Artikli { get; set; }

    }
}
