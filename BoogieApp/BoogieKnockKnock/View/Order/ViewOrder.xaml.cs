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
    public partial class ViewOrder : ContentPage
    {
        private ViewOrderViewModel SCVM;
        public ViewOrder()
        {
            InitializeComponent();

            SCVM = Dependencies.Resolve<ViewOrderViewModel>();
            BindingContext = SCVM;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            SCVM.NavigatetoOrder.Execute(sender);
            ((ListView)sender).SelectedItem = null;
        }
    }
}