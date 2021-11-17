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
    public partial class NotifikacijeDetaljiPage : ContentPage
    {
        private NotifikacijeDetaljiViewModel viewModel= null;
        public NotifikacijeDetaljiPage(NotifikacijeDetaljiViewModel model)
        {
            InitializeComponent();
            BindingContext = viewModel = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Init();
        }

        public NotifikacijeDetaljiPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NotifikacijeDetaljiViewModel(null); 
        }
    }
}