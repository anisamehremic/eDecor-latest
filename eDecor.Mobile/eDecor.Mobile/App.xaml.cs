using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eDecor.Mobile.Services;
using eDecor.Mobile.Views;

namespace eDecor.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new PrijaviSePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
