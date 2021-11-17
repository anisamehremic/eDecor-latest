using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class PretplateUpsertRequest
    {
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int KlijentId { get; set; }
        [Required]
        public int KategorijaId { get; set; }
    }
}
