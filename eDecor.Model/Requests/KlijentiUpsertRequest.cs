using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class KlijentiUpsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public DateTime DatumRegistracije { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public int GradId { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public bool Status { get; set; }
        public string Lozinka { get; set; }
        public string PotvrdaLozinke { get; set; }
    }
}
