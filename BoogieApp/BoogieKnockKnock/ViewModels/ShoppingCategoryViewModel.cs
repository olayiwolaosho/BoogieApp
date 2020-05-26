using BoogieApp.BoogieKnockKnock.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class ShoppingCategoryViewModel
    {
        public ObservableCollection<ShoppingCategoriesModel> categoriesModels { get; set; }  

        public ShoppingCategoryViewModel()
        {
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
                   ImageUrl = "Grocery.jpg",
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
                   ImageUrl = "Grocery.jpg",
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
                   ImageUrl = "Grocery.jpg",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               },
               new ShoppingCategoriesModel()
               {
                   Title = "Grocery",
                   ImageUrl = "Grocery.jpg",
                   Description  = "Lets help you get Groceries from your favourite supermarket"

               }
           };
        }
    }
}
