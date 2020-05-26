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
    public partial class ShoppingCategories : ContentPage
    {
        public ShoppingCategories()
        {
            InitializeComponent();

            BindingContext = new ShoppingCategoryViewModel();
        }
    }
}