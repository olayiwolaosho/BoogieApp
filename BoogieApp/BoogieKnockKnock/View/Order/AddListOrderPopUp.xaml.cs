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
    public partial class AddListOrderPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddListOrderPopUp()
        {
            InitializeComponent();
        }
    }
}