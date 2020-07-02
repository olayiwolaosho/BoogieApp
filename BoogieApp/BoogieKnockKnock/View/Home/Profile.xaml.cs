using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieKnockKnock.View.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentView
    {
        public Profile()
        {
            InitializeComponent();

            BindingContext = Dependencies.Resolve<ProfileViewModel>();
        }
    }
}