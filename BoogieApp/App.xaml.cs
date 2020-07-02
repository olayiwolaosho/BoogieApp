using BoogieApp.BoogieFuelme.Services.GoogleMaps;
using BoogieApp.BoogieFuelme.Views.AuthenticationView;
using BoogieApp.BoogieKnockKnock.View;
using BoogieApp.BoogieKnockKnock.View.SharpnadoPages;
using BoogieApp.Constants;
using BoogieApp.DependencyInjection;
using BoogieApp.GeneralServices.DependencyService;
using BoogieApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Init();
            if(Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                  MainPage = new NavigationPage(new Bottomtabbedpage());
             //   MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
           
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

        public void Init()
        {
            Device.SetFlags(new string[] { "Expander_Experimental" });
            GoogleMapsApiService.Initialize(Constant.GoogleMapsApiKey);
            Dependencies.RegisterDependencies();
            if (!Preferences.ContainsKey("DeviceID"))
            {
                IDevice device = DependencyService.Get<IDevice>();
                string deviceIdentifier = device.GetIdentifier();

                Preferences.Set("DeviceID", deviceIdentifier);

            }


        }
    }
}
