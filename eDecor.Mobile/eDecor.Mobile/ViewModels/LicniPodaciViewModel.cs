using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eDecor.Mobile.ViewModels
{
    public class LicniPodaciViewModel : BaseViewModel
    {
        private readonly APIService _klijentiService = new APIService("Klijenti");
        private readonly APIService _gradoviService = new APIService("Gradovi");

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }
        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        string _novaLozinka = string.Empty;
        public string NovaLozinka
        {
            get { return _novaLozinka; }
            set { SetProperty(ref _novaLozinka, value); }
        }
        string _potrdanoveLozinke = string.Empty;
        public string PotvrdaNoveLozinke
        {
            get { return _potrdanoveLozinke; }
            set { SetProperty(ref _potrdanoveLozinke, value); }
        }

        private Model.Gradovi _selectedGrad = null;
        public Model.Gradovi SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }
        public ObservableCollection<Model.Gradovi> gradoviList { get; set; } = new ObservableCollection<Model.Gradovi>();

        public ICommand InitCommand { get; set; }
        public ICommand UrediCommand { get; set; }

        public LicniPodaciViewModel()
        {
            InitCommand = new Command(async () => await Init());
            UrediCommand = new Command(async () => await Uredi());
        }

        public async Task Uredi()
        {
            var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
            if (result.Count != 0)
            {
                if (Lozinka.Equals(APIService.Password))
                {
                    try
                    {
                        KlijentiUpsertRequest request = new KlijentiUpsertRequest()
                        {
                            Ime = Ime,
                            Prezime = Prezime,
                            Telefon = Telefon,
                            Email = Email,
                            GradId = SelectedGrad.GradId,
                            KorisnickoIme = KorisnickoIme,
                            Lozinka = NovaLozinka,
                            PotvrdaLozinke = PotvrdaNoveLozinke,
                            DatumRegistracije = DateTime.Now,
                            Status = true,
                        };

                        var entity = await _klijentiService.Update<Model.Klijenti>(result[0].KlijentId, request);
                        if (entity != null)
                        {
                            await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno obavljeno", "Uredu");
                            if (!string.IsNullOrWhiteSpace(request.Lozinka))
                                APIService.Password = request.Lozinka;
                        }

                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "Uredu");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešna lozinka!", "Uredu");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prijavite se!", "Uredu");
                Application.Current.MainPage = new eDecor.Mobile.Views.PrijaviSePage();
                return;
            }
        }

        public async Task Init()
        {
            try
            {
                var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                if (result.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Prijavite se!", "Uredu");
                    Application.Current.MainPage = new eDecor.Mobile.Views.PrijaviSePage();
                    return;
                }
                Ime = result[0].Ime;
                Prezime = result[0].Prezime;
                Telefon = result[0].Telefon;
                Email = result[0].Email;
                KorisnickoIme = result[0].KorisnickoIme;

                if (gradoviList.Count == 0)
                {
                    var items = await _gradoviService.Get<List<Model.Gradovi>>(null);
                    foreach (var item in items)
                    {
                        gradoviList.Add(item);
                        if(item.GradId == result[0].GradId)
                        {
                            SelectedGrad = item;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<bool> txtEmail_Validating()
        {
            var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
            if (result.Count == 1)
            {
                var list = await _klijentiService.Get<List<Model.Klijenti>>(null);
                foreach (var item in list)
                    if (item.Email == Email && item.KlijentId != result[0].KlijentId)
                    {
                        return false;
                    }
                return true;
            }
            return false;
        }
    }
}
