using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class KategorijeUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
