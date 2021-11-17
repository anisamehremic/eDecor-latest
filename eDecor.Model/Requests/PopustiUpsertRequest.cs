using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eDecor.Model.Requests
{
    public class PopustiUpsertRequest
    {
        [Required]
        public string Kod { get; set; }
        [Required]
        public decimal Popust { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
