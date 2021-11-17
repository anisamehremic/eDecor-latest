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
    public class NovaNarudzbaDetaljiViewModel : BaseViewModel
    {
        private readonly APIService _popustiService = new APIService("Popusti");
        public readonly APIService _klijentiService = new APIService("Klijenti");
        public readonly APIService _gradoviService = new APIService("Gradovi");
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");

        Model.Gradovi _selectedGrad = null;
        public Model.Gradovi SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
            }
        }

        byte[] _slika = null;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }
        string _cijena = string.Empty;
        public string Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }
        string _nativ = string.Empty;
        public string Naziv
        {
            get { return _nativ; }
            set { SetProperty(ref _nativ, value); }
        }
        string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        string _kolicina = "1";
        public string Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
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

        string _ukupno = string.Empty;
        public string Ukupno
        {
            get { return _ukupno; }
            set { SetProperty(ref _ukupno, value); }
        }

        public double UkupnoZaPlatiti = 0;

        public ObservableCollection<Model.Artikli> artikliList { get; set; } = new ObservableCollection<Model.Artikli>();
        public ObservableCollection<Model.Gradovi> gradList { get; set; } = new ObservableCollection<Model.Gradovi>();

        private Model.Artikli Artikal { get; set; }

        public NovaNarudzbaDetaljiViewModel(Model.Artikli artikal = null)
        {
            Artikal = artikal;
        }
        public async Task Init()
        {
            IsBusy = true;
            try
            {
                //var list = await _rezervacijeService.Get<List<Model.Rezervacije>>(new RezervacijeSearchRequest() { Klijent = APIService.Username });
                if (gradList.Count == 0)
                {
                    gradList.Clear();
                    var gradoviList = await _gradoviService.Get<List<Model.Gradovi>>(null);
                    gradoviList.ForEach(x => gradList.Add(x));
                }
                if (Artikal != null)
                {
                    Naziv = Artikal.Naziv;
                    Cijena = Artikal.Cijena.ToString();
                    Opis = Artikal.Opis;
                    Slika = Artikal.Slika;
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

        public async Task<bool> IsValidate()
        {
            try
            {
                if (SelectedGrad == null || string.IsNullOrWhiteSpace(Adresa))
                {
                    await Application.Current.MainPage.DisplayAlert("Obavezno polje", $"Obavezan unos grada i adrese!", "Uredu");
                    return false;
                }
                int kolicina = 1;
                try
                {
                    kolicina = int.Parse(Kolicina);
                    if (kolicina <= 0 || kolicina > 100)
                    {
                        await Application.Current.MainPage.DisplayAlert("Obavjest", $"Kolicina koji ste unijeli nije ispravan(od 1 do 100)!", "Uredu");
                        return false;
                    }
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavjest", $"Kolicina koji ste unijeli nije cijeli broj!", "Uredu");
                    return false;
                }

                UkupnoZaPlatiti = (double)Artikal.Cijena * kolicina;
                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
                return false;
            }
        }
        public async Task<RezervacijeUpsertRequest> PripremiModel()
        {
            try
            {
                var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                RezervacijeUpsertRequest request = new RezervacijeUpsertRequest()
                {
                    DatumKreiranja = DateTime.Now,
                    Status = true,
                    Adresa = Adresa,
                    GradId = SelectedGrad.GradId,
                    KorisnikId = null,
                    KlijentId = result[0].KlijentId,
                    PopustId = null,
                    Napomena = Napomena
                };
                request.Artikli = new List<Model.RezervacijeArtikli>();
                request.Artikli.Add(new Model.RezervacijeArtikli() { ArtikalId = Artikal.ArtikalId, Kolicina = int.Parse(Kolicina), Status = true });

                double? popust = null;
                if (!string.IsNullOrWhiteSpace(Popust))
                {
                    List<Model.Popusti> list = await _popustiService.Get<List<Model.Popusti>>(null);
                    foreach (var item in list)
                    {
                        if (item.Kod.ToUpper().Equals(Popust.ToUpper()))
                        {
                            request.PopustId = item.PopustId;
                            popust = (double)item.Popust;
                        }
                    }

                    if (request.PopustId == null)
                        await Application.Current.MainPage.DisplayAlert("Obavjest", $"Kod koji ste unijeli nije ispravan!", "Uredu");
                }

                if (popust.HasValue && popust.Value > 0)
                    UkupnoZaPlatiti = UkupnoZaPlatiti - ((popust.Value * UkupnoZaPlatiti) / 100);

                return request;
            }
            catch (Exception ex){
                return null;
            }
        }

        public async Task Save()
        {
            try
            {
                var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                RezervacijeUpsertRequest request = new RezervacijeUpsertRequest()
                {
                    DatumKreiranja = DateTime.Now,
                    Status = true,
                    Adresa = Adresa,
                    GradId = SelectedGrad.GradId,
                    KorisnikId = null,
                    KlijentId = result[0].KlijentId,
                    PopustId = null,
                    Napomena = Napomena
                };
                request.Artikli = new List<Model.RezervacijeArtikli>();
                request.Artikli.Add(new Model.RezervacijeArtikli() { ArtikalId = Artikal.ArtikalId, Kolicina = int.Parse(Kolicina), Status = true });

                if (!string.IsNullOrWhiteSpace(Popust))
                {
                    List<Model.Popusti> list = await _popustiService.Get<List<Model.Popusti>>(null);
                    foreach (var item in list)
                    {
                        if (item.Kod.ToUpper().Equals(Popust.ToUpper()))
                        {
                            request.PopustId = item.PopustId;
                        }
                    }

                    if (request.PopustId == null)
                        await Application.Current.MainPage.DisplayAlert("Obavjest", $"Kod koji ste unijeli nije ispravan!", "Uredu");
                }
                Model.Rezervacije entity = null;
                entity = await _rezervacijeService.Insert<Model.Rezervacije>(request);
                if (entity != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno kreirana narudžba!", "Uredu");
                    await Init();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
