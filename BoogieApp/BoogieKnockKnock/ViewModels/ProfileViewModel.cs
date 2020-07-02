using BoogieApp.BoogieKnockKnock.View;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {

        }        
        public ICommand SelectPaymentMethod => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddCreditCard());
            //await NavigationService.NavigateToAsync<AddCreditCardViewModel>(order);
            // await navigation.PushAsync(new AddCreditCard());
        });
        
    }
}
