using Autofac;
using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.DependencyInjection;
using StoresResponseObjects;
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
        FavouriteShopViewModel FSVM;

        StoresResponseObjects.Datum[] storesResponse;

        public FavouriteShopView(StoresResponseObjects.Datum[] storesResponse)
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                FSVM = Dependencies.container.Resolve<FavouriteShopViewModel>();
            }
            //   RPVM = new RegistrationDataPageViewModel(new NavigationService(),new LocationServices())
            BindingContext = FSVM;
            this.storesResponse = storesResponse;
        }

        protected async override void OnAppearing()
        {
            await FSVM.Viewshops(storesResponse);
            base.OnAppearing();
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