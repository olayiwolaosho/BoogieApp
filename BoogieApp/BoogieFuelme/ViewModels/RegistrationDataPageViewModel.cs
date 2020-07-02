using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.BoogieFuelme.Views.AuthenticationView;
using BoogieApp.Constants;
using BoogieApp.GeneralServices.AuthenticationService;
using BoogieApp.GeneralServices.Location;
using BoogieApp.GeneralServices.Navigation;
using BoogieApp.GeneralServices.RequestProvider;
using BoogieApp.VerificationConfigs;
using BoogieApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoogieApp.BoogieFuelme.ViewModels
{
    public class RegistrationDataPageViewModel : RegistrationPageViewModel
    {
       protected IAuthenticationService authenticationService;
        public ICommand Getlocation { get; set; }
        public ICommand Locate { get; set; }

        public RegistrationDataPageViewModel(INavigationService navigationService, ILocationServices locationServices, IAuthenticationService authenticationService) : base(navigationService,locationServices)
        {
            IsBusy = true;
            IsNotBusy = false;
            BusyLayout = false;
            Visiblebutton = true;
            ButtonActivity = false;
            this.authenticationService = authenticationService;
            // Locate = new Command(async () => await Getalllocatio());
            //  Getlocation = new Command<double>(async (double latlong) => await GetCurrentLocation());

        }

        // Visibility of the button submit button
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
        
        //The activity Indicator that activates when button is pressed
        bool _buttonActivity = false;
        public bool ButtonActivity
        {
            get => _buttonActivity;
            set
            {
                _buttonActivity = value;
                RaisePropertyChanged(() => ButtonActivity);
            }
        }

        //Checks if the Getlocation Command has been excuted
        bool _locationGotten = false;
        public bool LocationGotten
        {
            get => _locationGotten;
            set
            {
                _locationGotten = value;
                RaisePropertyChanged(() => LocationGotten);
            }
        }

        //Email
        string _useremail;
        public string Useremail { get => _useremail;
            set
            {
                _useremail = value;
                RaisePropertyChanged(() => Useremail);
                Preferences.Set("Useremail", _useremail);
            }
        }

        //Password
        string _userpasswords;
        public string Userpasswords { get => _userpasswords;
            set
            {
                _userpasswords = value;
                RaisePropertyChanged(() => Userpasswords);
                
            }
        }

        //Username
        string _username;
        public string Username { get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
                Preferences.Set("Username", _username);
            }
        }

        //Phonenumber
        string _usermobile;
        public string Usermobile { get => _usermobile;
            set
            {
                _usermobile = value;
                RaisePropertyChanged(() => Usermobile);
                Preferences.Set("Usermobile", _usermobile);
            }
        }

    //    //Latitude
    //    double _userLat;
    //    public double UserLat {
    //        get => Convert.ToDouble(_originLatitud);
       

    //}

    //    //Longitude
    //    string _userLong;
    //    public string UserLong
    //    {
    //        get => _originLongitud;
    //        set
    //        {

    //           _originLongitud = value;

    //        }

    //    }

        //device id
        public string device_id
        {
            get
            {
                if (Preferences.ContainsKey("DeviceID"))
                {
                    return Preferences.Get("DeviceID", null);
                }
                return "";
            }
        }

        //fcm_token this is gotten from firebase
        public string fcm_token { get; set; }

        // ID Of location comming from hosted database

        string _locationid;
        public string Locationid { get => _locationid;
            set
            {
                _locationid = value;
                RaisePropertyChanged(() => Locationid);
            }
        }

        //The locations coming from the data base  
        public string AllLocations { get; set; }

        public ICommand PhoneAuth => new Command(async () =>
        {
            Visiblebutton = false;
            ButtonActivity = true;
            if (await HorribleTemporaryValidation())
            {
                    try
                    {
                        var response = await Configs.VerifyPhonenumberorEmail(Usermobile, Useremail);

                        if (response.code == 200)
                        {
                        Preferences.Set("latitude", _originLatitud);
                        Preferences.Set("longitude", _originLongitud);
                        Preferences.Set("LocationSelected", LocationSelected.LocationName);
                        Application.Current.Properties["password"] = Userpasswords;

                        await Application.Current.SavePropertiesAsync();
                        await Application.Current.MainPage.DisplayAlert("", "Verification code has been sent to your mobile number and email", "Ok");
                          await _navigationService.NavigateToPageAsync<Verification>(new Verification());
                        //     IsNotBusy = false;
                        //   BusyLayout = true;
                    }
                    else
                        {
                            await Application.Current.MainPage.DisplayAlert("Boogie", "Invalid Phonenumber or Email", "Ok");
                        //  await _navigationService.NavigateToPageAsync<Verification>(new Verification());
                         }
                    }
                    catch(Exception)
                    {
                    await Application.Current.MainPage.DisplayAlert("Boogie", "Invalid Phonenumber or Email", "Ok");
                    // await _navigationService.NavigateToPageAsync<Verification>(new Verification());
                    Visiblebutton = true;
                    ButtonActivity = false;
                    }     
            }
            Visiblebutton = true;
            ButtonActivity = false;

        });


        //Want to implement validation quick THIS IS THE WRONG WAY TO IMPLEMENT THIS
        private async Task<bool> HorribleTemporaryValidation()
        {
            if (!(string.IsNullOrEmpty(Useremail) || string.IsNullOrEmpty(Usermobile)))
            {
                if(!string.IsNullOrEmpty(Username))
                {
                    if (!string.IsNullOrEmpty(Userpasswords) &&  Userpasswords.Length > 5)
                    {
                        if (!string.IsNullOrEmpty(Useraddress))
                        {
                            if (LocationSelected != null)
                            {
                                if (Usermobile.Length == 11)
                                {
                                    return true;
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Invalid Mobilenumber", "Mobile number incomplete", "Ok");
                                    return false;
                                }   
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Invalid UserLocation", "Location cannot be empty", "Ok");
                                return false;
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Invalid Useraddress", "Address cannot be empty", "Ok");
                            return false;
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Invalid Userpassword", "password must contain at least 6 digits", "Ok");
                        return false;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Invalid Username", "username cannot be empty", "Ok");
                    return false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid cridentials", "useremail or umobilenumber invalid", "Ok");
                return false;
            }
        }


        //Verification

        private bool _busyLayout = false;

        public bool BusyLayout
        {
            get
            {
                return _busyLayout;
            }

            set
            {
                _busyLayout = value;
                RaisePropertyChanged(() => BusyLayout);
            }
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

        public ICommand OnClear => new Command(() =>
        {
            Firsttext = "";

            Secondtext = "";

            Thirdtext = "";

            Fourthtext = "";
        });

        //public ICommand Verify => new Command(async () =>
        //{
           
        //    var response = Configs.VerifyCode(WrittenCode);
        //    if (response.code == 200 || response.code == 402)
        //    {
        //        try
        //        {
        //            BusyLayout = false;
        //            var success = await authenticationService.Registration(Username, Useremail, Usermobile, Userpassword, Useraddress, "customer", Preferences.Get("DeviceID", null),
        //       LocationSelected.Id, _originLatitud, _originLongitud, "22xx", "No", "No");

        //            if (success.Status)
        //            {
        //                await Application.Current.MainPage.DisplayAlert("", "Registration Successful", "Ok");
        //                Application.Current.Properties["UserEmail"] = Useremail;
        //                Preferences.Set("UserEmail", Useremail);
        //                Application.Current.Properties["UserName"] = Username;
        //                Application.Current.Properties["UserMobile"] = Usermobile;
        //                Application.Current.Properties["UserAddress"] = Useraddress;
        //                Application.Current.Properties["LocationSelected"] = LocationSelected.LocationName;
        //                Application.Current.Properties["Fcm_Token"] = "22xx";

        //                await Application.Current.SavePropertiesAsync();
        //               _navigationService.ConvertToMainPage<LoginPage>(new LoginPage());
        //            }

        //        }
        //        catch
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Invalid Code", "Registration Unsuccessful Phonenumber or email has already been registered ", "Ok");
        //            IsNotBusy = true;
        //        }
        //    }
        //    else
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Invalid Code", "You have entered the wrong code", "Ok");
        //        IsNotBusy = true;
        //    }
        //});
    }
}
