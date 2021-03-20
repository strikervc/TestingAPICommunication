using System;
using TestingAPICommunication.Services;
using TestingAPICommunication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingAPICommunication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
