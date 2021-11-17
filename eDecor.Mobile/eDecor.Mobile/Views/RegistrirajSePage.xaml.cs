using eDecor.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eDecor.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrirajSePage : ContentPage
    {
        RegistrirajSeViewModel viewModel;
        public RegistrirajSePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new RegistrirajSeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
            //viewModel.InitCommand.Execute(null);
        }

        private async void RegistrujSe_Clicked(object sender, EventArgs e)
        {

            if (viewModel == null)
                return;


            if (IsValidateText(Ime) && IsValidateText(Prezime) && IsValidateText(KorisnickoIme) && Email_Validating() && Telefon_Validating() && Lozinka_Validating())
            {
                if (viewModel.SelectedGrad == null) {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste odabrali grad", "Uredu");
                }
                else if (!await viewModel.txtKorisnickoIme_Validating())
                {
                    KorisnickoIme.Placeholder = "Korisničko ime već postoji!";
                    KorisnickoIme.PlaceholderColor = Color.FromHex("#ff4d4d");
                    KorisnickoIme.Text = string.Empty;
                }
                else if (!await viewModel.txtEmail_Validating())
                {
                    Email.Placeholder = "Email već postoji!";
                    Email.PlaceholderColor = Color.FromHex("#ff4d4d");
                    Email.Text = string.Empty;
                }
                else
                {
                    await viewModel.RegistrirajSe();
                }
            }
        }

        private bool Lozinka_Validating()
        {
            if (string.IsNullOrWhiteSpace(Lozinka.Text))
            {
                Lozinka.TextColor = Color.FromHex("#ff4d4d");
                Lozinka.Placeholder = "Obavezno polje!";
                Lozinka.PlaceholderColor = Color.FromHex("#ff4d4d");

                PotvrdaLozinke.TextColor = Color.FromHex("#ff4d4d");
                PotvrdaLozinke.Placeholder = "Obavezno polje!";
                PotvrdaLozinke.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (Lozinka.Text != PotvrdaLozinke.Text)
            {
                Lozinka.TextColor = Color.FromHex("#ff4d4d");
                Lozinka.Placeholder = "Obavezno polje!";
                Lozinka.PlaceholderColor = Color.FromHex("#ff4d4d");

                PotvrdaLozinke.TextColor = Color.FromHex("#ff4d4d");
                PotvrdaLozinke.Placeholder = "Obavezno polje!";
                PotvrdaLozinke.PlaceholderColor = Color.FromHex("#ff4d4d");
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
        private void KorisnickoIme_Focused(object sender, FocusEventArgs e)
        {
            KorisnickoIme.TextColor = Color.Black;
        }
        private void Lozinka_Focused(object sender, FocusEventArgs e)
        {
            Lozinka.TextColor = Color.Black;
            PotvrdaLozinke.TextColor = Color.Black;
        }
    }
}