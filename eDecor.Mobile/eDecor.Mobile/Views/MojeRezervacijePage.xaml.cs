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
    public partial class MojeRezervacijePage : ContentPage
    {
        private MojeRezervacijeViewModel viewModel = null;
        public MojeRezervacijePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MojeRezervacijeViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsBusy = true;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Model.Rezervacije)layout.BindingContext;
            await Navigation.PushAsync(new MojeRezervacijeDetaljiPage(item));
        }
    }
}