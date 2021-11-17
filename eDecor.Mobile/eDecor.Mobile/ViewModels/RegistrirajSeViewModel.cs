using eDecor.Mobile.Views;
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
    class RegistrirajSeViewModel : BaseViewModel
    {
        private readonly APIService _gradoviService = new APIService("Gradovi");
        private readonly APIService _klijentiService = new APIService("Klijenti");
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

        string _potvrdaLozinke = string.Empty;
        public string PotvrdaLozinke
        {
            get { return _potvrdaLozinke; }
            set { SetProperty(ref _potvrdaLozinke, value); }
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
        public ICommand PrijaviSeCommand { get; set; }
        public ICommand RegistrirajSeCommand { get; set; }

        public RegistrirajSeViewModel()
        {
            InitCommand = new Command(async () => await Init());
            PrijaviSeCommand = new Command(() => PrijaviSe());
            RegistrirajSeCommand = new Command(async () => await RegistrirajSe());
        }

        public async Task Init()
        {
            try
            {
                if (gradoviList.Count == 0)
                {
                    var items = await _gradoviService.Get<List<Model.Gradovi>>(null);
                    foreach (var item in items)
                    {
                        gradoviList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task RegistrirajSe()
        {
            var request = new KlijentiUpsertRequest()
            {
                Ime = Ime,
                Prezime = Prezime,
                Email = Email,
                Telefon = Telefon,
                GradId = _selectedGrad.GradId,
                KorisnickoIme = KorisnickoIme,
                Lozinka = Lozinka,
                PotvrdaLozinke = PotvrdaLozinke,
                DatumRegistracije = DateTime.Now,
                Status = true
            };

            try
            {
                var item = await _klijentiService.Insert<Model.Klijenti>(request);

                await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste se registrirali!", "Uredu");
                Application.Current.MainPage = new PrijaviSePage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Obavjest", ex.Message, "Uredu");
            }
        }
        public async Task<bool> txtKorisnickoIme_Validating()
        {
            var result = await _klijentiService.Get<List<Model.Klijenti>>(null);
            foreach (var item in result)
                if (item.KorisnickoIme == KorisnickoIme)
                {
                    return false;
                }
            return true;
        }
        public async Task<bool> txtEmail_Validating()
        {
            var result = await _klijentiService.Get<List<Model.Klijenti>>(null);
            foreach (var item in result)
                if (item.Email == Email)
                {
                    return false;
                }
            return true;
        }
        private void PrijaviSe()
        {
            Application.Current.MainPage = new PrijaviSePage();
        }
    }
}
