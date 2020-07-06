using BoogieApp.BoogieKnockKnock.View.Order;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace BoogieApp.BoogieKnockKnock.ViewModels
{
    class PlaceOrderViewModel : BaseViewModel
    {
        public PlaceOrderViewModel(INavigationService navigationService) : base(navigationService)
        {


        }

        public ICommand ListOrder => new Command(async () =>
        {
            await _navigationService.NavigateToPageAsync<Page>(new ListOrderView());
        });

        public ICommand VoiceOrder => new Command(async () =>
        {
            await _navigationService.NavigateToPageAsync<Page>(new VoiceOrderView());
        });
        
        public ICommand PictureOrder => new Command(async () =>
        {
            await _navigationService.NavigateToPageAsync<Page>(new PictureOrderView());
        });
        
        public ICommand WhatsappOrder => new Command(async () =>
        {
            Chat.Open("2348172321197", "I Want to order something");
        });
    }
}
