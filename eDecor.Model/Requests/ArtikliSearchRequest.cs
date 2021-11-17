using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model.Requests
{
    public class ArtikliSearchRequest
    {
        public string Naziv { get; set; }
        public int? KategorijaID { get; set; }
        public int? PodkategorijaID { get; set; }
    }
}
