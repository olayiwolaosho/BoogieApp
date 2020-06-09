using BoogieApp.BoogieKnockKnock.Models;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class NotificationViewModel : BaseViewModel
    {
        public ObservableCollection<NotificationModel> Notification { get; set; }

        public NotificationViewModel()
        {
            Notification = new ObservableCollection<NotificationModel>()
            {
               new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                   Description = "Order Complete",

               },
               new NotificationModel()
               {
                   Title = "Grocery",
                  Description = "Check In on Incomplete Order",

               },
                new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                    Description = "Check In on Incomplete Order",

               },
               new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                   Description = "Order Complete",

               },

               new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                    Description = "Check In on Incomplete Order",

               },
               new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                   Description = "Order Complete",

               },

                new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                   Description = "Check In on Incomplete Order",

               },
                new NotificationModel()
               {
                   Title = "Home Affairs Supermarket",
                    Description = "Order Complete",

               },
           };
        }
    }
}
