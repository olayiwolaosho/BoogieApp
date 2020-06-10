using System;
using System.Collections.Generic;
using BoogieApp.ViewModels;
using Xamarin.Forms;

namespace BoogieApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModels();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }

        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}
