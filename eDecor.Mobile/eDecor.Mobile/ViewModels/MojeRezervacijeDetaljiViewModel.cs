using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eDecor.Mobile.ViewModels
{
    public class MojeRezervacijeDetaljiViewModel : BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");
        private readonly APIService _ocjeneService = new APIService("Ocjene");

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        string _grad = string.Empty;
        public string Grad
        {
            get { return _grad; }
            set { SetProperty(ref _grad, value); }
        }

        string _datumKreiranja = string.Empty;
        public string DatumKreiranja
        {
            get { return _datumKreiranja; }
            set { SetProperty(ref _datumKreiranja, value); }
        }

        string _popust = string.Empty;
        public string Popust
        {
            get { return _popust; }
            set { SetProperty(ref _popust, value); }
        }

        string _napomena = string.Empty;
        public string Napomena
        {
            get { return _napomena; }
            set { SetProperty(ref _napomena, value); }
        }
        string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        string _cijena = string.Empty;
        public string Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }
        string _ukupno = string.Empty;
        public string Ukupno
        {
            get { return _ukupno; }
            set { SetProperty(ref _ukupno, value); }
        }

        int _ocjena = 10;
        public int Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }
        
        string _placeno = string.Empty;
        public string Placeno
        {
            get { return _placeno; }
            set { SetProperty(ref _placeno, value); }
        }

        string _iznosAvansnogPlacanje = string.Empty;
        public string IznosAvansnogPlacanje
        {
            get { return _iznosAvansnogPlacanje; }
            set { SetProperty(ref _iznosAvansnogPlacanje, value); }
        }

        public ObservableCollection<Model.Artikli> artikliList { get; set; } = new ObservableCollection<Model.Artikli>();

        private Model.Rezervacije Rezervacija { get; set; }
        public ICommand InitCommand { get; set; }

        public MojeRezervacijeDetaljiViewModel(Model.Rezervacije rezervacija = null)
        {
            Rezervacija = rezervacija;
            InitCommand = new Command(async () => await Init());
        }
        public readonly APIService _klijnetiService = new APIService("Klijenti");
        public async Task Init()
        {
            IsBusy = true;
            var list = await _rezervacijeService.Get<List<Model.Rezervacije>>(new RezervacijeSearchRequest() { Klijent = APIService.Username });
            try
            {
                if (Rezervacija != null)
                {
                    Adresa = Rezervacija.Adresa;
                    Grad = Rezervacija.Grad.Naziv;
                    DatumKreiranja = Rezervacija.DatumKreiranja.ToString("dd.MM.yyyy HH:mm");
                    Status = Rezervacija.Status ? "Aktivna" : "Otkazana";
                    Napomena = Rezervacija.Napomena;

                    IznosAvansnogPlacanje = Rezervacija.IznosAvansnogPlacanje + " KM";
                    Placeno = Rezervacija.Placeno ? "Da" : "Ne";

                    artikliList.Clear();
                    double suma = 0;
                    Model.RezervacijeArtikli artikal = null;
                    foreach (var item in Rezervacija.RezervacijeArtikli)
                    {
                        if(artikal==null)
                            artikal = item;
                        item.Artikal.Kolicina = item.Kolicina;
                        artikliList.Add(item.Artikal);
                        suma += item.Kolicina * (double)item.Artikal.Cijena;
                    }

                    var result = await _ocjeneService.Get<List<Model.Ocjene>>(new OcjeneSearchRequest() { ArtikalId = artikal.ArtikalId, KlijentId = Rezervacija.KlijentId });
                    if(result.Count != 0)
                        Ocjena = result[0].Ocjena;

                    Cijena = suma + " KM";
                    Ukupno = suma + " KM";
                    Popust = Rezervacija.Popust?.Popust.ToString() ?? "0";
                    if(!Popust.Equals("0"))
                        Ukupno = Math.Round(suma - ((double)Rezervacija.Popust.Popust.Value * suma / 100), 2) + " KM";//s popustom
                    Popust = Popust + " %";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OtkaziRezervaciju()
        {
            if (Rezervacija != null)
            {
                if (Rezervacija.Status)
                {
                    var totalDay = (int)(DateTime.Now.Date - Rezervacija.DatumKreiranja.Date).TotalDays;
                    if (totalDay > 1)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", $"Rezervaciju nemoguće otkazati!", "OK");
                    }
                    else
                    {

                        Rezervacija.Status = false;

                        RezervacijeUpsertRequest request = new RezervacijeUpsertRequest()
                        {
                            KlijentId = Rezervacija.KlijentId,
                            PopustId = Rezervacija.PopustId,
                            GradId = Rezervacija.GradId,
                            Adresa = Rezervacija.Adresa,
                            KorisnikId = Rezervacija.KorisnikId,
                            DatumKreiranja = Rezervacija.DatumKreiranja,
                            Napomena = Rezervacija.Napomena,
                            Status = Rezervacija.Status
                        };
                        request.Artikli = new List<Model.RezervacijeArtikli>();
                        foreach (var operma in Rezervacija.RezervacijeArtikli)
                        {
                            request.Artikli.Add(operma);
                        }

                        try
                        {
                            Model.Rezervacije entity = null;
                            entity = await _rezervacijeService.Update<Model.Rezervacije>(Rezervacija.RezervacijaId, request);
                            if (entity != null)
                            {
                                await Application.Current.MainPage.DisplayAlert("Obavjest", "Rezervacija uspješno otkazana!", "OK");
                                await Init();
                            }
                        }
                        catch
                        {
                            await Application.Current.MainPage.DisplayAlert("Greška", "Greška na serveru!", "Uredu");
                        }
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Rezervacija već otkazana!", "Uredu");
                }
            }
        }
        public async Task OcjeniNarudzbu() {
            try
            {
                Model.RezervacijeArtikli artikal = null;
                foreach (var item in Rezervacija.RezervacijeArtikli)
                {
                    if (artikal == null)
                        artikal = item;
                }
                var result = await _ocjeneService.Get<List<Model.Ocjene>>(new OcjeneSearchRequest() { ArtikalId = artikal.ArtikalId, KlijentId = Rezervacija.KlijentId });

                if (result.Count != 0)
                {
                    await _ocjeneService.Update<Model.Ocjene>(result[0].OcjenaId, new OcjeneUpsertRequest() { ArtikalId = result[0].ArtikalId, KlijentId = result[0].KlijentId, Ocjena = Ocjena, Datum = result[0].Datum});
                    await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste izmijenili ocjenu!", "Uredu");

                }
                else
                {
                    await _ocjeneService.Insert<Model.Ocjene>(new OcjeneUpsertRequest() { ArtikalId = artikal.ArtikalId, KlijentId = Rezervacija.KlijentId.Value, Ocjena = Ocjena, Datum = DateTime.Now.Date });
                    await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste ocijenili artikal!", "Uredu");
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Greška na serveru!", "Uredu");
            }
        }
    }
}
