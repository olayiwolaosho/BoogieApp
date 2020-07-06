using Autofac;
using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View.ShoppingViews.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrderView : ContentPage
    {
        private PlaceOrderViewModel SCVM;
        public PlaceOrderView()
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                SCVM = Dependencies.container.Resolve<PlaceOrderViewModel>();
            }
            BindingContext = SCVM;
        }
    }
}