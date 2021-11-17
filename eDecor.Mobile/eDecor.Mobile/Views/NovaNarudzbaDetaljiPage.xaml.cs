using eDecor.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eDecor.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaNarudzbaDetaljiPage : ContentPage
    {
        NovaNarudzbaDetaljiViewModel viewModel = null;
        public NovaNarudzbaDetaljiPage(Model.Artikli artikli)
        {
            InitializeComponent();
            BindingContext = viewModel = new NovaNarudzbaDetaljiViewModel(artikli);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (await viewModel.IsValidate())
                {
                    if (await Application.Current.MainPage.DisplayAlert("Pitanje", $"Da li želite izvršiti plaćanje narudžbe ili uplatu avansa?", "Da", "Ne"))
                    {
                        var result = await viewModel.PripremiModel();
                        if(result!= null)
                            await Navigation.PushAsync(new AvansnoPlacanjePage(result, viewModel.UkupnoZaPlatiti));
                    }
                    else
                        await viewModel.Save();
                }
            }
            catch (Exception) { 
            
            }
        }
    }
}