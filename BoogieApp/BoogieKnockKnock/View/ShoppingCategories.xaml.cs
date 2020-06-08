using BoogieApp.BoogieKnockKnock.ViewModels;
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

    public partial class ShoppingCategories : ContentView
    {
        ShoppingCategoryViewModel SCVM => BindingContext as ShoppingCategoryViewModel; 
        public ShoppingCategories()
        {
            InitializeComponent();
                          
            BindingContext = new ShoppingCategoryViewModel(this.Navigation);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            SCVM.NavigatetofavShop.Execute(sender);
            ((ListView)sender).SelectedItem = null;
        }
    }
}