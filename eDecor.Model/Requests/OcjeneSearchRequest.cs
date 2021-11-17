using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model.Requests
{
    public class OcjeneSearchRequest
    {
        public int? Ocjena { get; set; }
        public string Artikal { get; set; }
        public int? ArtikalId { get; set; }
        public int? KlijentId { get; set; }
    }
}
