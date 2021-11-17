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
    public partial class NotifikacijePage : ContentPage
    {
        private NotifikacijeViewModel viewModel = null;
        public NotifikacijePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NotifikacijeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Model.Notifikacije)layout.BindingContext;
            viewModel.SelectedNotifikacija = item;
            if(item.Status)
                await Navigation.PushAsync(new NotifikacijeDetaljiPage(new NotifikacijeDetaljiViewModel(item)));
        }
    }
}