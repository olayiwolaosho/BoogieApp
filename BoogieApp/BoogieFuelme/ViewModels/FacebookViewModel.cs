using BoogieApp.BoogieFuelme.Model;
using BoogieApp.BoogieFuelme.Services.Facebook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.BoogieFuelme.ViewModels
{
    class FacebookViewModel : INotifyPropertyChanged
    {
        private FacebookProfile _facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();

            try
            {
                FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
                if(FacebookProfile != null)
                {
                   // await App.Current.MainPage.Navigation.PushAsync()
                }
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("", "Cannot log you into facebook", "ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
