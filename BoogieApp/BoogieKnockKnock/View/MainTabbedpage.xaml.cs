using BoogieApp.BoogieKnockKnock.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            NavigationPage ShoppingPage = new NavigationPage(new ShoppingCategories());
            ShoppingPage.IconImageSource = "weshop.png";
            ShoppingPage.Title = "Shop";
            Children.Add(ShoppingPage); 
            
            NavigationPage OrderPage = new NavigationPage(new ShoppingCategories());
            OrderPage.IconImageSource = "business.png";
            OrderPage.Title = "Order";
            Children.Add(OrderPage); 
            
            NavigationPage DashboardPage = new NavigationPage(new Dashboard());
            DashboardPage.IconImageSource = "user.png";
            DashboardPage.Title = "Dashboard";
            Children.Add(DashboardPage);

            NavigationPage ExtraPage = new NavigationPage(new ShoppingCategories());
            ExtraPage.IconImageSource = "business.png";
            ExtraPage.Title = "Order";
            Children.Add(ExtraPage);
        }
    }
}