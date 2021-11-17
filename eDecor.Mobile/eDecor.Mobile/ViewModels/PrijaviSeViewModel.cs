using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using eDecor.Mobile.Models;
using eDecor.Mobile.Views;
using eDecor.Model;
using eDecor.Model.Requests;
using System.Collections.Generic;
using Flurl.Http;
using System.Windows.Input;

namespace eDecor.Mobile.ViewModels
{
    public class PrijaviSeViewModel : BaseViewModel
    {
        private readonly APIService _ulogeService = new APIService("Uloge");
        private readonly APIService _klijentiServices = new APIService("Klijenti");

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand PrijaviSeCommand { get; set; }
        public ICommand RegistrirajSeCommand { get; set; }

        public PrijaviSeViewModel()
        {
            Title = "Prijavi se";
            PrijaviSeCommand = new Command(async () => await PrijaviSe());
            RegistrirajSeCommand = new Command(() => { RegistrirajSe(); });

        }

        private void RegistrirajSe()
        {
           Application.Current.MainPage = new RegistrirajSePage();
        }

        private async Task PrijaviSe()
        {
            IsBusy = true;

            APIService.Username = _username;
            APIService.Password = _password;

            try
            {
                await _ulogeService.Get<dynamic>(null);

                List<Klijenti> klijentiList = await _klijentiServices.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                if (klijentiList.Count == 1)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
                }
            }
            catch //(FlurlHttpException ex)
            {
                //await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}