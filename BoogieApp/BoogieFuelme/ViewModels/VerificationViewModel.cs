using Autofac.Features.AttributeFilters;
using BoogieApp.GeneralServices.AuthenticationService;
using BoogieApp.GeneralServices.Location;
using BoogieApp.GeneralServices.Navigation;
using BoogieApp.VerificationConfigs;
using BoogieApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoogieApp.BoogieFuelme.ViewModels
{
    public class VerificationViewModel : RegistrationDataPageViewModel
    {
        public VerificationViewModel(INavigationService navigationService, ILocationServices locationServices, IAuthenticationService authenticationService) : base(navigationService, locationServices, authenticationService)
        {
        }

        string _firsttext;
        public string Firsttext
        {
            get => _firsttext;
            set
            {
                _firsttext = value;
                RaisePropertyChanged(() => Firsttext);
            }
        }
        string _secondntext;
        public string Secondtext
        {
            get => _secondntext;
            set
            {
                _secondntext = value;
                RaisePropertyChanged(() => Secondtext);
            }
        }
        string _thirdtext;
        public string Thirdtext
        {
            get => _thirdtext;
            set
            {
                _thirdtext = value;
                RaisePropertyChanged(() => Thirdtext);
            }
        }
        string _fourthtext;
        public string Fourthtext
        {
            get => _fourthtext;
            set
            {
                _fourthtext = value;
                RaisePropertyChanged(() => Fourthtext);
            }
        }

        //The Code written by the current user
        public string WrittenCode
        {
            get => $"{Firsttext}{Secondtext}{Thirdtext}{Fourthtext}";
            set
            {
                RaisePropertyChanged(() => WrittenCode);
            }
        }

        public ICommand Verify => new Command(async () =>
        {

            var response = Configs.VerifyCode(WrittenCode);
            if (response.code == 200 || response.code == 402)
            {
                try
                {
                    var name = Preferences.Get("Username", null);
                    var mobile = Preferences.Get("Usermobile", null);
                    var email = Preferences.Get("Useremail", null);
                    var locid = Preferences.Get("Locationid", 0L);
                    var lat =  Preferences.Get("latitude", null);
                    var address = Preferences.Get("Useraddress", null);
                    var DiviceID = Preferences.Get("DeviceID", null);
                    var longi = Preferences.Get("longitude", null);
                    var newpass = Application.Current.Properties["password"].ToString();
                    BusyLayout = false;
                    var success = await authenticationService.Registration(name, email, mobile, newpass, address, "customer", DiviceID, locid, lat, longi, "22xx", "No", 0);

                    if (success.Status)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Registration Successful", "Ok");
                        Preferences.Set("Username", name);
                        Preferences.Set("Usermobile", mobile);
                        Preferences.Set("Useremail", email);
                        Preferences.Set("Userpassword", newpass);
                        Preferences.Set("Locationid",locid);
                        Preferences.Set("latitude", lat);
                        Preferences.Set("Useraddress",address);
                        Preferences.Set("longitude", longi);
                        Application.Current.Properties["Fcm_Token"] = "22xx";

                        await Application.Current.SavePropertiesAsync();
                        _navigationService.ConvertToMainPage<LoginPage>(new LoginPage());
                    }

                }
                catch
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Code", "Registration Unsuccessful Phonenumber or email has already been registered ", "Ok");
                    IsNotBusy = true;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Code", "You have entered the wrong code", "Ok");
                IsNotBusy = true;
            }
        });
    }
}
