using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.View.Order;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class ViewOrderViewModel : BaseViewModel
    {
        public ObservableCollection<Order> order { get; set; }
        public ObservableCollection<Order> vieworder { get; set; }
        public ViewOrderViewModel()
        {
            order = new ObservableCollection<Order>
           {
              new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                      "2X FiveAlive, 1X Brandy, 3X Toilet Paper"
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                      "Shopcity",
                  },
                  orderprogress = "Pending",
                  Date = "Today: 5:15pm"
              },  
                
              new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                      "2X FiveAlive, 1X Brandy, 3X Toilet Paper"
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                      "D'Prince ",
                  },
                  orderprogress = "Completed",
                  Date = "Today: 5:15pm"
              },
                
               new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                  },
                  orderprogress = "Declined",
                  Date = "Today: 5:15pm"
              }, 
                
                new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                  },
                  orderprogress = "Declined",
                  Date = "Today: 5:15pm"
              },

                 new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                      "2X FiveAlive, 1X Brandy, 3X Toilet Paper"
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                      "D'Prince ",
                  },
                  orderprogress = "Completed",
                  Date = "Today: 5:15pm"
              },

                  new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                      "2X FiveAlive, 1X Brandy, 3X Toilet Paper"
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                      "Shopcity",
                  },
                  orderprogress = "Pending",
                  Date = "Today: 5:15pm"
              },

           };   
            vieworder = new ObservableCollection<Order>
           {
              new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                      "2X FiveAlive, 1X Brandy, 3X Toilet Paper"
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                      "D'Prince ",
                  },
                  orderprogress = "Completed",
                  Date = "Today: 5:15pm"
              },
                
               new Order
              {
                  orders = new List<string>
                  {
                      "2X Sardine, 1X Bread, 3X Eggs, 5X Coke Pet",
                  },

                  Shopname = new List<string>
                  {
                      "Home Affairs",
                  },
                  orderprogress = "Declined",
                  Date = "Today: 5:15pm"
              }, 
             
           };
        }

        public ICommand NavigatetoOrder => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new OrderDetail());
        });
    }
}
