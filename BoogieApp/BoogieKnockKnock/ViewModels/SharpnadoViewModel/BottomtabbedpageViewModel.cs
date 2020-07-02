using BoogieApp.BoogieKnockKnock.View.Order;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.GeneralServices.ItemServices;
using BoogieApp.GeneralServices.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel
{
    class BottomtabbedpageViewModel : BaseViewModel
    {
        ICategoryService categoryService;
        public BottomtabbedpageViewModel(INavigationService navigationService,ICategoryService categoryService) : base(navigationService)
        {
            this.categoryService = categoryService;
        }

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

        public async Task GetCategory()
        {
            var locationid = Application.Current.Properties["locationID"].ToString();
            try
            {
                var categories = await categoryService.categoryResponse(locationid);
                MessagingCenter.Send(this, "Categorylist", categories);
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("No internet connection", "Please connect to internet", "Ok");
            }
           

        }
       
    }
}
