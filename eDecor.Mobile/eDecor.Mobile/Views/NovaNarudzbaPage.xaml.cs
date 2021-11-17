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
    public partial class NovaNarudzbaPage : ContentPage
    {
        NovaNarudzbaViewModel viewModel = null;
        public NovaNarudzbaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NovaNarudzbaViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await viewModel.Init();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Model.Artikli)layout.BindingContext;
            Navigation.PushAsync(new NovaNarudzbaDetaljiPage(item));
        }
    }
}