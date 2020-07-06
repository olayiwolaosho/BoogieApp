using BoogieApp.BoogieFuelme.ViewModels;
using BoogieApp.Constants;
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
    public partial class FacebookLogin : ContentPage
    {
        public FacebookLogin()
        {
            InitializeComponent();

            var apiRequest =
               "https://www.facebook.com/dialog/oauth?client_id="
               + Constant.ClientId
               + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";

            //var apiRequest =
            //     "https://www.facebook.com/v7.0/dialog/oauth?client_id="
            //     + Constant.ClientId + "&display=popup & response_type = token" + "&redirect_uri =https://www.facebook.com/connect/login_success.html" +
            // "&state ={st=state123abc,ds=123456789}";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var vm = BindingContext as FacebookViewModel;

                await vm.SetFacebookUserProfileAsync(accessToken);

                Content = MainStackLayout;
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }
    }
}