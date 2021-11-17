using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class NotifikacijeUpsertRequest
    {
        [Required]
        public DateTime DatumSlanja { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int KorisnikId { get; set; }
        public int? KlijentId { get; set; }
    }
}
