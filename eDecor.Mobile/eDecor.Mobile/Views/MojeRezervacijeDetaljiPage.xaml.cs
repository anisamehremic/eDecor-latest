using eDecor.Mobile.ViewModels;
using eDecor.Model;
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
    public partial class MojeRezervacijeDetaljiPage : ContentPage
    {
        MojeRezervacijeDetaljiViewModel viewModel;
        public MojeRezervacijeDetaljiPage(Rezervacije model = null)
        {
            InitializeComponent();
            BindingContext = this.viewModel = new MojeRezervacijeDetaljiViewModel(model);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await viewModel.OtkaziRezervaciju();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
        }

        private async void Button_Clicked_Ocjena(object sender, EventArgs e)
        {
            await viewModel.OcjeniNarudzbu();
        }
    }
}