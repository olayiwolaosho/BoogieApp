using Autofac;
using BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel;
using BoogieApp.DependencyInjection;
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
        private BottomtabbedpageViewModel RPVM;
        public Bottomtabbedpage()
        {
            InitializeComponent();
            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                RPVM = Dependencies.container.Resolve<BottomtabbedpageViewModel>();
            }
            BindingContext = RPVM;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await RPVM.GetCategory();
        }
    }
}