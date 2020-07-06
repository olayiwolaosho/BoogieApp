using Rg.Plugins.Popup.Extensions;
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
    public partial class ListOrderView : ContentPage
    {
        public ListOrderView()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AddListOrderPopUp());
        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
           // Grouplistview.ItemsSource = App.Database.GetAllGroups().Where(a => a.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        private void Grouplistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

         //   var item = e.SelectedItem as Group;
         //   Navigation.PushAsync(new MembersInGroupPage(item));
            Grouplistview.SelectedItem = null;
        }
    }
}