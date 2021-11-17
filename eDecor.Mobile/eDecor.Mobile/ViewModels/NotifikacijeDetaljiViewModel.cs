using eDecor.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eDecor.Mobile.ViewModels
{
    public class NotifikacijeDetaljiViewModel : BaseViewModel
    {
        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }

        string _sadrzaj = string.Empty;
        public string Sadrzaj
        {
            get { return _sadrzaj; }
            set { SetProperty(ref _sadrzaj, value); }
        }

        string _autor = string.Empty;
        public string Autor
        {
            get { return _autor; }
            set { SetProperty(ref _autor, value); }
        }

        string _datumSlanja = DateTime.Now.ToString();
        public string DatumSlanja
        {
            get { return _datumSlanja; }
            set { SetProperty(ref _datumSlanja, value); }
        }

        byte[] _slika = null;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

        public Model.Notifikacije Notifikacija { get; set; }
        public ICommand InitCommand { get; set; }

        public NotifikacijeDetaljiViewModel(Model.Notifikacije notifikacija = null)
        {
            Notifikacija = notifikacija;
            InitCommand = new Command(() => Init());
        }
        public NotifikacijeDetaljiViewModel()
        {
        }
        public void Init()
        {
            Naziv = Notifikacija.Naziv;
            Sadrzaj = Notifikacija.Sadrzaj;
            DatumSlanja = Notifikacija.DatumSlanja.ToString("dd.MM.yyyy HH:mm");
            Autor = Notifikacija.Korisnik.Ime + " " + Notifikacija.Korisnik.Prezime + " ";
            Slika = Notifikacija.Slika;
        }
    }

}
