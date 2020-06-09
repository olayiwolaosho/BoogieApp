using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.BoogieKnockKnock.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel => throw new NotImplementedException();

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task RemoveBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
