using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class OrderDetailViewModel : BaseViewModel
    {
        public OrderDetailViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
