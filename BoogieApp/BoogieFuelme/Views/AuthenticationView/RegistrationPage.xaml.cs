using BoogieApp.BoogieFuelme.ViewModels;
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
        RegistrationPageViewModel RPVM => BindingContext as RegistrationPageViewModel;  
        public static readonly BindableProperty FocusOriginCommandProperty =
           BindableProperty.Create(nameof(FocusOriginCommand), typeof(ICommand), typeof(RegistrationPage), null, BindingMode.TwoWay);
        public RegistrationPage()
        {
            InitializeComponent();

              MessagingCenter.Subscribe<RegistrationPageViewModel,ObservableCollection<Model.GooglePlaceAutoCompletePrediction>>(this, "Place", (sender,args) =>
              {
                  list.ItemsSource = args;
              });
           
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
            originEntry.Focus();
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
            bottom.IsFrameEnabled = true;
            MessagingCenter.Send(this, "Expand");
         //   bottomSheet.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
          //  bottom.PercentageHideBottomSheet = 0.1;
            MessagingCenter.Send(this, "Close");
          //  bottom.PercentageHideBottomSheet = 0.7;
            //bottomSheet.IsVisible = false;
        }

    }
}