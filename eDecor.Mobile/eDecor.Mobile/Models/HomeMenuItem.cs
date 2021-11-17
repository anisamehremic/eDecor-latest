using System;
using System.Collections.Generic;
using System.Text;

namespace eDecor.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Notifikacije,
        PretplatiSe,
        MojePretplate,
        NovaNarudzba,
        MojeNarudzbe,
        LicniPodaci,
        OdjaviSe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
