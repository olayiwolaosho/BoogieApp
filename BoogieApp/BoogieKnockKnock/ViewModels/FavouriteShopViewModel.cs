using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.View.ShoppingViews.Order;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class FavouriteShopViewModel : BaseViewModel
    {
        public ObservableCollection<FavouriteShopModel> favouriteShops { get; set; }

        public ObservableCollection<StoresResponseObjects.Datum> StoresModels = new ObservableCollection<StoresResponseObjects.Datum>();
        public ObservableCollection<StoresResponseObjects.Datum> storesModels
        {
            get => StoresModels;
            set
            {
                StoresModels = value;
                RaisePropertyChanged(() => storesModels);
            }
        }

        public FavouriteShopViewModel(INavigationService navigationService) : base(navigationService)
        {
           // favouriteShops = new ObservableCollection<FavouriteShopModel>()
           //{
           //    new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
           //    new FavouriteShopModel()
           //    {
           //        Title = "Grocery",
           //        ImageUrl = "Grocery.jpg",

           //    },
           //     new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
           //    new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
                
           //    new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },   
           //    new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
                
           //     new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
           //     new FavouriteShopModel()
           //    {
           //        Title = "Home Affairs Supermarket",
           //        ImageUrl = "Grocery.jpg",

           //    },
           //};
        }

        public ICommand NavigatetofavShop => new Command(async () =>
        {
           await _navigationService.NavigateToPageAsync<Page>(new PlaceOrderView());
        });

        public async Task Viewshops(StoresResponseObjects.Datum[] args)
        {
            storesModels = new ObservableCollection<StoresResponseObjects.Datum>(args);
        }
    }
}
