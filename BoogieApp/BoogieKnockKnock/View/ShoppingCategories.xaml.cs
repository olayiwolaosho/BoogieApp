using Autofac;
using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.DependencyInjection;
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
        private ShoppingCategoryViewModel SCVM;
        public ShoppingCategories()
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                SCVM = Dependencies.container.Resolve<ShoppingCategoryViewModel>();
            }
            //   RPVM = new RegistrationDataPageViewModel(new NavigationService(),new LocationServices())
            BindingContext = SCVM;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
              ((ListView)sender).SelectedItem = null;
            var currentcategory = (BoogieApp.BoogieFuelme.Model.ResponseObjects.Datum)e.SelectedItem;
            await SCVM.NavigatetoShop(currentcategory);
          
        }
          
    }
}