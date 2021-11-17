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
    public partial class MojePretplatePage : ContentPage
    {
        private MojePretplateViewModel viewModel = null;
        public MojePretplatePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MojePretplateViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();
           
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Model.Pretplate)layout.BindingContext;
            if (item != null)
            {
                viewModel.SelectedPretplata = item;
            }
        }
    }
}