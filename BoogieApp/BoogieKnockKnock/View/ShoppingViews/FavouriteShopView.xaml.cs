using BoogieApp.BoogieKnockKnock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View.ShoppingViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouriteShopView : ContentPage
    {
        FavouriteShopViewModel FSVM => BindingContext as FavouriteShopViewModel;

        public FavouriteShopView()
        {
            InitializeComponent();

            BindingContext = new FavouriteShopViewModel(this.Navigation);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

           FSVM.NavigatetofavShop.Execute(sender);
            ((ListView)sender).SelectedItem = null;
        }
    }
}