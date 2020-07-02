using System;
using System.Collections.Generic;
using Autofac;
using BoogieApp.DependencyInjection;
using BoogieApp.ViewModels;
using Xamarin.Forms;

namespace BoogieApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModels VVM;
        public LoginPage()
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                VVM = Dependencies.Resolve<LoginViewModels>();
            }
            BindingContext = VVM;
        }

       
    }
}
