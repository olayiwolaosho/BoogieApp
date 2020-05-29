using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.View.ShoppingViews.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class FavouriteShopViewModel
    {
        private INavigation navigation;
        public ObservableCollection<FavouriteShopModel> favouriteShops { get; set; }

        public FavouriteShopViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            favouriteShops = new ObservableCollection<FavouriteShopModel>()
           {
               new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
               new FavouriteShopModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Grocery.jpg",

               },
                new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
               new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
                
               new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },   
               new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
                
                new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
                new FavouriteShopModel()
               {
                   Title = "Home Affairs Supermarket",
                   ImageUrl = "Grocery.jpg",

               },
           };
        }

        public ICommand NavigatetofavShop => new Command(async () =>
        {
           await navigation.PushAsync(new PlaceOrderView());
        });
    }
}
