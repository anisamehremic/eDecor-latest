using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Model
{
    public class Drzave
    {
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv; 
        }
    }
}
