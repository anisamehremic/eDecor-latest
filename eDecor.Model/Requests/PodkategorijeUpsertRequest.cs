using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class PodkategorijeUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required]
        public int KategorijaId { get; set; }
    }
}
