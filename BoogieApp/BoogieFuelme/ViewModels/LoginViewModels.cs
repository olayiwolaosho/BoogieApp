using BoogieApp.BoogieFuelme.Model;
using BoogieApp.BoogieFuelme.Services.Facebook;
using BoogieApp.BoogieFuelme.Views.AuthenticationView;
using BoogieApp.BoogieKnockKnock.View.SharpnadoPages;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.AuthenticationService;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoogieApp.ViewModels
{
    public class LoginViewModels : BaseViewModel
    {
        IAuthenticationService authenticationService;

        public LoginViewModels(INavigationService navigationService,IAuthenticationService authenticationService) :base(navigationService)
        {
            this.authenticationService = authenticationService;
            Visiblebutton = true;
           Activitybutton = false;
        }

        private FacebookProfile _facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                RaisePropertyChanged(() => FacebookProfile);
            }
        }

        bool _visiblebutton = false;
        public bool Visiblebutton
        {
            get => _visiblebutton;
            set
            {
                _visiblebutton = value;
                RaisePropertyChanged(() => Visiblebutton);
            }
        }

        bool _activitybutton = false;
        public bool Activitybutton
        {
            get => _activitybutton;
            set
            {
                _activitybutton = value;
                RaisePropertyChanged(() => Activitybutton);
            }
        }

        string phone; 
        public string Phonenumber { get 
            {
                if (Preferences.ContainsKey("UserMobile"))
                {
                    return Preferences.Get("UserMobile", null);
                }
                return phone;
            } //Application.Current.Properties["UserEmail"].ToString();
            set 
            {
                phone = value;
                RaisePropertyChanged(() => Phonenumber);
            } 
        }

        string password;
        public string Password { get => password; 
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public ICommand registerhere => new Command(async() =>
        {
            await _navigationService.NavigateToPageAsync<RegistrationPage>(new RegistrationPage());
        }); 
        
        public ICommand loginwithfacebook => new Command(async() =>
        {
            //var facebookServices = new FacebookServices();
            await _navigationService.NavigateToPageAsync<Page>(new FacebookLogin());
            //FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
        });

        

        public ICommand loginsuccess => new Command(async () =>
        {
            Visiblebutton = false;
            Activitybutton = true;

            try
            {
                if(await HorribleTemporaryValidation())
                {
                    var DeviceId = Preferences.Get("DeviceID", null);
                    var success = await authenticationService.SignIn(Phonenumber, Password, "22xx", DeviceId, "customer", DateTime.Now);
                    if (success.Status)
                    {
                        Preferences.Set("LocationSelected", success.Data.LocationName);
                        Application.Current.Properties["LoggedIn"] = true;
                        Application.Current.Properties["locationID"] = success.Data.LocationId;
                        await Application.Current.SavePropertiesAsync();
                        await Application.Current.MainPage.DisplayAlert("Login Successful", "", "Ok");
                        _navigationService.ConvertToMainPage<Bottomtabbedpage>(new Bottomtabbedpage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Invalid Credentials", "Please confirm phonenumber and password", "Ok");
                        Visiblebutton = true;
                        Activitybutton = false;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Credentials", "Please confirm phonenumber and password", "Ok");
                    Visiblebutton = true;
                    Activitybutton = false;
                }
              
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Credentials", "Please confirm phonenumber and password", "Ok");
                Visiblebutton = true;
                Activitybutton = false;
            }
          
        });

        private async Task<bool> HorribleTemporaryValidation()
        {
            if(!(string.IsNullOrEmpty(phone) || string.IsNullOrWhiteSpace(phone)))
            {
                if(!(string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password) || password.Length < 6))
                {
                    return true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Incorrect Password", "Password cannot be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Phonenumber", "Mobile number cannot be empty", "Ok");
                return false;
            }
        }

    }
}
