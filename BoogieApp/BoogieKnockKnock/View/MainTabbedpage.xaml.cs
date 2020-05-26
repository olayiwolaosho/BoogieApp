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
    public partial class MainTabbedpage : TabbedPage
    {
        public MainTabbedpage()
        {
            InitializeComponent();

            NavigationPage navigationPage = new NavigationPage(new ShoppingCategories());
            navigationPage.IconImageSource = "business.png";
            navigationPage.Title = "shop";

            Children.Add(navigationPage);
        }
    }
}