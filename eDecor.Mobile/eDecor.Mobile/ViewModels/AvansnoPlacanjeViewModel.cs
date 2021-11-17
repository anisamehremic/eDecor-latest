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
using Stripe;
using System.Threading;
using Acr.UserDialogs;

namespace eDecor.Mobile.ViewModels
{
    public class AvansnoPlacanjeViewModel : BaseViewModel
    {
        private readonly APIService _ulogeService = new APIService("Uloge");
        private readonly APIService _klijentiServices = new APIService("Klijenti");
        private readonly APIService _rezervacijeServices = new APIService("Rezervacije");


        private string StripeTestApiKey = "pk_test_51I81rgE2sAx5hYKN5NIQypr8qXf0dsuHf1ijCWkhaI2h4BMLyMmVEiYKid4sPafEpSPTYuoSB2DTdPA6KpnOvkuo00KlZ9IbEF";

        private TokenService Tokenservice;
        private Token stripeToken;

        private bool _isCarcValid;
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        private bool _isTransectionSuccess;
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        private CreditCard _creditCardModel;
        public CreditCard CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        string _brojKartice = string.Empty;
        public string BrojKartice
        {
            get { return _brojKartice; }
            set { SetProperty(ref _brojKartice, value); }
        }

        string _cvc = string.Empty;
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }

        string _mjesec = string.Empty;
        public string Mjesec
        {
            get { return _mjesec; }
            set { SetProperty(ref _mjesec, value); }
        }

        string _godina = string.Empty;
        public string Godina
        {
            get { return _godina; }
            set { SetProperty(ref _godina, value); }
        }

        string _upanIznosZaPlatiti = string.Empty;
        public string UkupanIznosZaPlatiti
        {
            get { return _upanIznosZaPlatiti; }
            set { SetProperty(ref _upanIznosZaPlatiti, value); }
        }


        string _iznos = string.Empty;
        public string Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }


        public RezervacijeUpsertRequest request = null;
        public double ukupanIznos = 0;

        public AvansnoPlacanjeViewModel(RezervacijeUpsertRequest Request, double UkupanIznos)
        {
            UkupanIznosZaPlatiti = $"Vaš račun iznosi {UkupanIznos} KM";
            request = Request;
            ukupanIznos = UkupanIznos;
        }

        public async Task<bool> IsValid()
        {
            try
            {
                long number;
                bool success = long.TryParse(BrojKartice, out number);
                if (!success || BrojKartice.Length != 16)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Broj kartice mora sadržavati šesnaest cifara!", "Uredu");
                    return false;
                }
                int broj;
                success = int.TryParse(Mjesec, out broj);
                if (!success || Mjesec.Length != 2)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Mjesec mora sadržavati dvije cifre!", "Uredu");
                    return false;
                }
                success = int.TryParse(Godina, out broj);
                if (!success || Godina.Length != 2)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Godina mora sadržavati dvije cifre!", "Uredu");
                    return false;
                }
                success = int.TryParse(Cvc, out broj);
                if (!success || Cvc.Length != 3)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "CVC mora sadržavati tri cifre!", "Uredu");
                    return false;
                }

                double iznos;
                success = double.TryParse(Iznos, out iznos);
                if (!success || iznos <= 0 || iznos > ukupanIznos)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Iznos nije ispravno unešen!", "Uredu");
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Broj kartice(16), mjesec(2), godina(2), cvv(3) i iznos moraju biti cijeli brojevi!", "Uredu");
                return false;
            }
        }
        public readonly APIService _klijentiService = new APIService("Klijenti");
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                var result = await _klijentiService.GetById<Model.Klijenti>(request.KlijentId);
                //korisnik

                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = $"{result.Ime} + {result.Prezime}",
                        AddressLine1 = "Gnojnice bb",
                        AddressLine2 = "Gnojnice 123",
                        AddressCity = "Mostar",
                        AddressZip = "88104",
                        AddressState = "Gnojnice",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MakePaymentAsync(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51I81rgE2sAx5hYKNCSsGDK7LiwCH17OUDh0r2KhLvDIXBQKifVC2qXWCxewAAJ7LQtcCEAegiJv4X7JLB4DlFPlp00W3xKrVkQ";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(ukupanIznos) * 100;
                options.Currency = "usd";
                options.Description = "Kupovina";
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = "test@test.com";
                var service = new ChargeService();
                Charge charge = service.Create(options);
                UserDialogs.Instance.Alert("Purchase was successful!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("(CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        public async Task Uplati()
        {
            Model.Rezervacije entity = null;
            
            CreditCardModel = new CreditCard();
            CreditCardModel.ExpMonth = Convert.ToInt64(Mjesec);
            CreditCardModel.ExpYear = Convert.ToInt64(Godina);
            CreditCardModel.Number = BrojKartice;
            CreditCardModel.Cvc = Cvc;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Payment processing ...");
                await Task.Run(async () =>
                {
                    var Token = CreateTokenAsync();
                    Console.Write("Token :" + Token);
                    if (Token.ToString() != null)
                    {
                        IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Bad Card Credentials", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write(ex.Message);
            }
            finally
            {
                try
                {
                    if (IsTransectionSuccess)
                    {

                        double iznos = double.Parse(Iznos);
                        request.IznosAvansnogPlacanje = (decimal)iznos;
                        request.Placeno = false;
                        if (iznos == ukupanIznos)
                            request.Placeno = true;

                        entity = await _rezervacijeServices.Insert<Model.Rezervacije>(request);
                        Console.Write($"Uspješno realizovana narudzba, uplaćeni avans: {ukupanIznos} KM!");
                        UserDialogs.Instance.HideLoading();
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        Console.Write("Payment Failure ");
                    }
                }
                catch (Exception) {
                    Console.Write("Transakcija nije uspjela!");
                }
            }
        }
    }
}