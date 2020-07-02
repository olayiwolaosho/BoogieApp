using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.View.Order;
using BoogieApp.BoogieKnockKnock.View.ShoppingViews;
using BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel;
using BoogieApp.GeneralServices.ItemServices;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class ShoppingCategoryViewModel : BoogieApp.BoogieKnockKnock.ViewModels.Base.BaseViewModel
    {
        private ICategoryService categoryService;
        public ObservableCollection<BoogieApp.BoogieFuelme.Model.ResponseObjects.Datum> CategoriesModels = new ObservableCollection<Datum>();
        public ObservableCollection<BoogieApp.BoogieFuelme.Model.ResponseObjects.Datum> categoriesModels
        {
            get => CategoriesModels;
            set
            {
                CategoriesModels = value;
                RaisePropertyChanged(() => categoriesModels);
            }
        }

        private string currentlocation;
        public string CurrentLocation
        {
            get
            {
                return currentlocation;
            }
            set
            {
                currentlocation = value;
                RaisePropertyChanged(() => CurrentLocation);

            }
        }

        public ShoppingCategoryViewModel(INavigationService navigationService,ICategoryService categoryService) : base(navigationService)
        {
            currentlocation = Preferences.Get("LocationSelected", null);
            this.categoryService = categoryService;
            MessagingCenter.Subscribe<BottomtabbedpageViewModel, CategoryResponse>(this, "Categorylist", (sender, args) =>
             {
                 categoriesModels = new ObservableCollection<Datum>(args.Data);
                // for(int i =0; i < args.Data.Length; i++)
                // {
                 //    categoriesModels.Add(args.Data[i]);
                 //}
                
             });

        }

        public async Task NavigatetoShop(BoogieApp.BoogieFuelme.Model.ResponseObjects.Datum categorydatum)
        {
            //  var locid = Convert.ToInt64(Application.Current.Properties["locationID"]);
            try
            {
                var success = await categoryService.storeresponse(categorydatum.Id);
                await _navigationService.NavigateToPageAsync<Page>(new FavouriteShopView(success.Data));
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", $"No Internet Connection{ex}", "Ok");
            }
         
        }
     
        
        public ICommand NavigateNotification => new Command(async () =>
        {
          //  await navigation.PushAsync(new NotificationView());
        });

        public async Task Main()
        {
          
        }



    }
}
