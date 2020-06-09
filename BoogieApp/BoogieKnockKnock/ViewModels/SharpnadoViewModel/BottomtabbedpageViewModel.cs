using BoogieApp.BoogieKnockKnock.View.Order;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel
{
    class BottomtabbedpageViewModel : BaseViewModel
    {
        private int _selectedViewModelIndex = 0;

        public int SelectedViewModelIndex
        {
            get =>  _selectedViewModelIndex;
            
            set
            {
                _selectedViewModelIndex = value;
                RaisePropertyChanged(() => SelectedViewModelIndex);
            }
        }

        public ICommand NavtoOrder => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PushAsync(new ViewOrder());
        });
       
    }
}
