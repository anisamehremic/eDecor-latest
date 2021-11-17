using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class ArtikliUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        [Required]
        public bool Status { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        [Required]
        public int KategorijaId { get; set; }
        [Required]
        public int PodkategorijaId { get; set; }
    }
}
