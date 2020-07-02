using BoogieApp.BoogieFuelme.Model;
using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.BoogieFuelme.Services;
using BoogieApp.BoogieFuelme.Services.GoogleMaps;
using BoogieApp.BoogieFuelme.Views.AuthenticationView;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.Constants;
using BoogieApp.GeneralServices.Location;
using BoogieApp.GeneralServices.Navigation;
using BoogieApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoogieApp.BoogieFuelme.ViewModels
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        private readonly ILocationServices _locationServices;
        public ICommand CalculateRouteCommand { get; set; }
        public ICommand UpdatePositionCommand { get; set; }

        public ICommand LoadRouteCommand { get; set; }
        public ICommand StopRouteCommand { get; set; }

        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();

        bool _hasRouteRunning;
       protected string _originLatitud;
        protected string _originLongitud;
        protected GooglePlace Place;
        string _destinationLatitud;
        string _destinationLongitud;

        //Address
        string _useraddress = "Address";
        public string Useraddress
        {
            get => _useraddress;
            set
            {
                _useraddress = value;
                RaisePropertyChanged(() => Useraddress);
                Preferences.Set("Useraddress", _useraddress);

            }
        }

        GooglePlaceAutoCompletePrediction _placeSelected;
        public GooglePlaceAutoCompletePrediction PlaceSelected
        {
            get
            {
                return _placeSelected;
            }
            set
            {
                _placeSelected = value;
                if (_placeSelected != null)
                    GetPlaceDetailCommand.Execute(_placeSelected);
            }
        }

        public ICommand FocusOriginCommand { get; set; }
        public ICommand GetPlacesCommand { get; set; }
        public ICommand GetPlaceDetailCommand { get; set; }

        private ObservableCollection<GooglePlaceAutoCompletePrediction> allplaces;
        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places
        {
            get => allplaces;
            set
            {
                allplaces = value;
                RaisePropertyChanged(() => Places);
            }
        }
        private ObservableCollection<GooglePlaceAutoCompletePrediction> _recentPlaces = new ObservableCollection<GooglePlaceAutoCompletePrediction>();
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get => _recentPlaces; set { _recentPlaces = value; RaisePropertyChanged(() => RecentPlaces); } }

        public bool ShowRecentPlaces { get; set; }
        bool _isPickupFocused = true;


        //User Location
        List<Model.ResponseObjects.Location> _locations = new List<Model.ResponseObjects.Location>();
        public List<Model.ResponseObjects.Location> MyLocations
        {
            get
            {
                return _locations; 
            }
            set
            {
                _locations = value;
                RaisePropertyChanged(() => MyLocations);
            }
        }

        private Model.ResponseObjects.Location locationselected;
        public Model.ResponseObjects.Location LocationSelected 
        {
            get => locationselected; 
            set
            {
                locationselected = value;
                RaisePropertyChanged(() => LocationSelected);
                Preferences.Set("Locationid", locationselected.Id);
            }    
        }

        string _pickupText;
        public string PickupText
        {
            get
            {
                return _pickupText;
            }
            set
            {
                _pickupText = value;
                if (!string.IsNullOrEmpty(_pickupText))
                {
                    _isPickupFocused = true;
                    GetPlacesCommand.Execute(_pickupText);
                }
            }
        } 
        
        
        Color _addresscolor = Color.FromRgb(102,102,102);
        public Color Addresscolor
        {
            get
            {
                return _addresscolor;
            }
            set
            {
                _addresscolor = value;
                RaisePropertyChanged(() => Addresscolor);
            }
        }

        string _originText;
        public string OriginText
        {
            get
            {
                return _originText;
            }
            set
            {
                _originText = value;
                if (!string.IsNullOrEmpty(_originText))
                {
                    _isPickupFocused = false;
                    GetPlacesCommand.Execute(_originText);
                }
            }
        }

        public RegistrationPageViewModel(INavigationService navigationService, ILocationServices locationServices) : base(navigationService)
        {
            // LoadRouteCommand = new Command(async () => await LoadRoute());
            // StopRouteCommand = new Command(StopRoute);
            this._locationServices = locationServices;
            GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
            GetPlaceDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
        }

        public async Task LoadRoute()
        {
            var positionIndex = 1;
            var googleDirection = await googleMapsApi.GetDirections(_originLatitud, _originLongitud, _destinationLatitud, _destinationLongitud);
            if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
            {

                
                var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
                CalculateRouteCommand.Execute(positions);

                _hasRouteRunning = true;

                //Location tracking simulation
                Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (positions.Count > positionIndex && _hasRouteRunning)
                    {
                        UpdatePositionCommand.Execute(positions[positionIndex]);
                        positionIndex++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(":(", "No route found", "Ok");
            }

        }

        public void StopRoute()
        {
            _hasRouteRunning = false;
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
            }
          //  MessagingCenter.Send(this, "Place", Places);

            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            Place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (Place != null)
            {
                Useraddress = Place.Name;
              //  if (_isPickupFocused)
              //  {
                    PickupText = Place.Name;
                    _originLatitud = $"{Place.Latitude}";
                    _originLongitud = $"{Place.Longitude}";
                    _isPickupFocused = false;
                Addresscolor = Color.Black;
                    MessagingCenter.Send<RegistrationPage>(new RegistrationPage(),"Close");
                 //   FocusOriginCommand.Execute();
              //  }
                //else
                //{
                //    _destinationLatitud = $"{Place.Latitude}";
                //    _destinationLongitud = $"{Place.Longitude}";

                //    RecentPlaces.Add(placeA);

                //    if (_originLatitud == _destinationLatitud && _originLongitud == _destinationLongitud)
                //    {
                //        await App.Current.MainPage.DisplayAlert("Error", "Origin route should be different than destination route", "Ok");
                //    }
                //    else
                //    {
                //    //  LoadRouteCommand.Execute(null);
                //        await App.Current.MainPage.Navigation.PopAsync(false);
                       
                //    }

                //}
               
            }
            CleanFields();
        }

        void CleanFields()
        {
            PickupText = OriginText = string.Empty;
            ShowRecentPlaces = true;
            PlaceSelected = null;

        }

        private bool _isNotBusy;

        public bool IsNotBusy
        {
            get
            {
                return _isNotBusy;
            }

            set
            {
                _isNotBusy = value;
                RaisePropertyChanged(() => IsNotBusy);
            }
        }

        public async Task Getalllocatio()
        {
            try
            {
                var locate = new Dictionary<string, object>()
                {
                    ["API_KEY"] = ApiConstants.API_KEY,
                };
                var loc = await _locationServices.GetAllLocations(locate);
                MyLocations = new List<Model.ResponseObjects.Location>(loc.Data);
                IsBusy = false;
                IsNotBusy = true;
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("No Network", "Please check your connection", "Ok");
                await Getalllocatio();
            }
          
        }

    }
}
