using eDecor.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eDecor.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LicniPodaciPage : ContentPage
    {
        private LicniPodaciViewModel viewModel = null;
        public LicniPodaciPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LicniPodaciViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }

        private async void Uredi_Clicked(object sender, EventArgs e)
        {
            if (viewModel == null)
                return;


            if (IsValidateText(Ime) && IsValidateText(Prezime) && IsValidateText(Lozinka) && Email_Validating() && Telefon_Validating() && Lozinka_Validating())
            {
                if (viewModel.SelectedGrad == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste odabrali grad", "Uredu");
                }
                else if (!await viewModel.txtEmail_Validating())
                {
                    Email.Placeholder = "Email već postoji!";
                    Email.PlaceholderColor = Color.FromHex("#ff4d4d");
                    Email.Text = string.Empty;
                }
                else
                {
                    await viewModel.Uredi();
                }
            }
        }

        private bool Lozinka_Validating()
        {
            if (NovaLozinka.Text != PotvrdaNoveLozinke.Text)
            {
                NovaLozinka.TextColor = Color.FromHex("#ff4d4d");
                NovaLozinka.Placeholder = "Obavezno polje!";
                NovaLozinka.PlaceholderColor = Color.FromHex("#ff4d4d");

                PotvrdaNoveLozinke.TextColor = Color.FromHex("#ff4d4d");
                PotvrdaNoveLozinke.Placeholder = "Obavezno polje!";
                PotvrdaNoveLozinke.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            return true;
        }
        private bool Email_Validating()
        {
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                Email.Placeholder = "Obavezno polje!";
                Email.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (!Regex.IsMatch(Email.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                Email.TextColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool Telefon_Validating()
        {
            if (string.IsNullOrWhiteSpace(Telefon.Text))
            {
                Telefon.Placeholder = "Obavezno polje!";
                Telefon.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (!Regex.IsMatch(Telefon.Text, @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}$") && !Regex.IsMatch(Telefon.Text, @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{4}$"))
            {
                Telefon.TextColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidateText(Entry entry)
        {
            if (string.IsNullOrEmpty(entry.Text))
            {
                entry.Placeholder = "Obavezno polje!";
                entry.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            return true;
        }
        private void Email_Focused(object sender, FocusEventArgs e)
        {
            Email.TextColor = Color.Black;
        }
        private void Telefon_Focused(object sender, FocusEventArgs e)
        {
            Telefon.TextColor = Color.Black;
        }
        private void NovaLozinka_Focused(object sender, FocusEventArgs e)
        {
            NovaLozinka.TextColor = Color.Black;
            PotvrdaNoveLozinke.TextColor = Color.Black;
            NovaLozinka.Placeholder = string.Empty;
            PotvrdaNoveLozinke.Placeholder = string.Empty;
        }
        private void Lozinka_Focused(object sender, FocusEventArgs e)
        {
            Lozinka.TextColor = Color.Black;
        }
    }
}