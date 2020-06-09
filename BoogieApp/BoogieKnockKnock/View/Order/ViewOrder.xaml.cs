using BoogieApp.BoogieKnockKnock.ViewModels;
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
        ViewOrderViewModel SCVM => BindingContext as ViewOrderViewModel;
        public ViewOrder()
        {
            InitializeComponent();
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