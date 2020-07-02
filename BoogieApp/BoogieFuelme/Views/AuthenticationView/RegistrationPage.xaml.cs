using Autofac;
using BoogieApp.BoogieFuelme.ViewModels;
using BoogieApp.DependencyInjection;
using BoogieApp.GeneralServices.Location;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieFuelme.Views.AuthenticationView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        int count = 0;
        private RegistrationDataPageViewModel RPVM;
        public static readonly BindableProperty FocusOriginCommandProperty =
           BindableProperty.Create(nameof(FocusOriginCommand), typeof(ICommand), typeof(RegistrationPage), null, BindingMode.TwoWay);
        public RegistrationPage()
        {
            InitializeComponent();

            using (var scope = Dependencies.container.BeginLifetimeScope())
            {
                RPVM = Dependencies.container.Resolve<RegistrationDataPageViewModel>();
            }
            //   RPVM = new RegistrationDataPageViewModel(new NavigationService(),new LocationServices())
            BindingContext = RPVM;

            MessagingCenter.Subscribe<RegistrationPageViewModel,ObservableCollection<Model.GooglePlaceAutoCompletePrediction>>(this, "Place", (sender,args) =>
              {
                  //list.ItemsSource = args;
              });
           
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await RPVM.Getalllocatio();
        }

        public ICommand FocusOriginCommand
        {
            get { return (ICommand)GetValue(FocusOriginCommandProperty); }
            set { SetValue(FocusOriginCommandProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                FocusOriginCommand = new Command(OnOriginFocus);
            }
        }

        void OnOriginFocus()
        {
            //originEntry.Focus();
        }

        void SearchBox_Focused(object sender, FocusEventArgs e)
        {
            if(count < 1)
            {
                MessagingCenter.Send(this, "Expand");
                count++;
            }
           
            // GridFilter.IsVisible = true;
            //  openBottomSheet();
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //bottom.IsFrameEnabled = true;
            MessagingCenter.Send(this, "Expand");
         //   bottomSheet.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Close");
            count = 0;
        }

        //Verification view
        //private void OnChange(Object sender, EventArgs e)
        //{

        //    if (firstKey.Text.Length > 0)
        //    {

        //        secondKey.Focus();

        //    }

        //}

        //private void OnChangeTwo(Object sender, EventArgs e)
        //{


        //    if (secondKey.Text.Length > 0)
        //    {

        //        thirdkey.Focus();

        //    }

        //}

        //private void OnChangeThree(Object sender, EventArgs e)
        //{


        //    if (thirdkey.Text.Length > 0)
        //    {

        //        foruthkey.Focus();

        //    }

        //}

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}