using Autofac;
using BoogieApp.BoogieFuelme.ViewModels;
using BoogieApp.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieFuelme.Views.AuthenticationView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Verification : ContentPage
    {
        private VerificationViewModel RPVM;
        public Verification()
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                RPVM = Dependencies.container.Resolve<VerificationViewModel>();
            }
            //   RPVM = new RegistrationDataPageViewModel(new NavigationService(),new LocationServices())
            BindingContext = RPVM;
        }

        private void OnChange(Object sender, EventArgs e)
        {

            if (firstKey.Text.Length > 0)
            {

                secondKey.Focus();

            }

        }

        private void OnChangeTwo(Object sender, EventArgs e)
        {


            if (secondKey.Text.Length > 0)
            {

                thirdkey.Focus();

            }

        }

        private void OnChangeThree(Object sender, EventArgs e)
        {


            if (thirdkey.Text.Length > 0)
            {

                foruthkey.Focus();

            }

        }
    }
}