using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : ContentPage
    {
     //   ViewOrderViewModel SCVM => this.BindingContext as ViewOrderViewModel;
        public OrderDetail()
        {
            InitializeComponent();
             BindingContext = Dependencies.Resolve<ViewOrderViewModel>();
        }
    }
}