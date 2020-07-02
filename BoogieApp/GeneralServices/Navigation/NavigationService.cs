using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoogieApp.GeneralServices.Navigation
{
    public class NavigationService : INavigationService
    {
        public View PreviousPageViewModel => (View)((Application.Current as App).MainPage.Navigation);

        public INavigation GetCurrentNavigation()
        {
          //  public Task PushAsync(Page page) => GetCurrentNavigation().PushAsync(page);
             return (Application.Current as App).MainPage.Navigation;
          
        }

        public async Task NavigateToPageAsync<TView>(Page page) where TView : Page
        {
            await GetCurrentNavigation().PushAsync(page, true); //(typeof(TViewModel), null);
        } 
        
        public void ConvertToMainPage<TView>(Page page) where TView : Page
        {
            (Application.Current as App).MainPage = new NavigationPage(page);
        }

        public async Task NavigateToAsync<TView>(object parameter) where TView : View
        {
          
        }

        public Task NavigateToAsync<TView>(View page) where TView : View
        {
            throw new NotImplementedException();
        }

        public Task RemoveBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLastFromBackStackAsync()
        {
            await GetCurrentNavigation().PopAsync();
        }
    }
}
