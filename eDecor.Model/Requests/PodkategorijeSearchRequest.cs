using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model.Requests
{
    public class PodkategorijeSearchRequest
    {
        public int? KategorijaID { get; set; }
        public string Naziv { get; set; }
    }
}
