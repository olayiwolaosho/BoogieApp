using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieKnockKnock.ViewModels.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {

        protected readonly INavigationService _navigationService;


        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public BaseViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
    }
}
