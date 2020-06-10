using BoogieApp.BoogieFuelme.Views.AuthenticationView;
using BoogieApp.BoogieKnockKnock.View;
using BoogieApp.BoogieKnockKnock.View.SharpnadoPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Expander_Experimental" });
            MainPage = new NavigationPage(new RegistrationPage());

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
