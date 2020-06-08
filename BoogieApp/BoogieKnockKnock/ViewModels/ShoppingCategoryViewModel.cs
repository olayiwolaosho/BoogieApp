using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.View.ShoppingViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class ShoppingCategoryViewModel
    {
        private INavigation navigation;
        public ObservableCollection<ShoppingCategoriesModel> categoriesModels { get; set; }  

        public ShoppingCategoryViewModel(INavigation navigation)
        {
            this.navigation = navigation;
           categoriesModels = new ObservableCollection<ShoppingCategoriesModel>()
           {
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Grocery.jpg",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },  
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Fuel.png",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Food.jpg",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Drinks.png",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Grocery.jpg",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Fuel.png",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
           };
        }

        public ICommand NavigatetofavShop => new Command(async () =>
        {
            await navigation.PushAsync(new FavouriteShopView());
        });

    }
}
