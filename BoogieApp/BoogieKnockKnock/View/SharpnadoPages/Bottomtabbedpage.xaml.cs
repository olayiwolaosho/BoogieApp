using BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View.SharpnadoPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bottomtabbedpage : ContentPage
    {
        public Bottomtabbedpage()
        {
            InitializeComponent();

            BindingContext = new BottomtabbedpageViewModel();
        }
    }
}