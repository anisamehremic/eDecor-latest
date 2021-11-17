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
    public partial class AvansnoPlacanjePage : ContentPage
    {
        private AvansnoPlacanjeViewModel viewModel = null;

        public AvansnoPlacanjePage(Model.Requests.RezervacijeUpsertRequest request, double UkupanIznos)
        {
            InitializeComponent();
            BindingContext = viewModel = new AvansnoPlacanjeViewModel(request, UkupanIznos);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await viewModel.IsValid())
                await viewModel.Uplati();
        }
    }
}