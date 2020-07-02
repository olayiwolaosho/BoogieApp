using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoogieApp.GeneralServices.Navigation
{
    public interface INavigationService
    {
        View PreviousPageViewModel { get; }

        INavigation GetCurrentNavigation();

        Task NavigateToAsync<TView>(View page) where TView : View;

        Task NavigateToPageAsync<TView>(Page page) where TView : Page;

        void ConvertToMainPage<TView>(Page page) where TView : Page;

        Task NavigateToAsync<TView>(object parameter) where TView : View;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
