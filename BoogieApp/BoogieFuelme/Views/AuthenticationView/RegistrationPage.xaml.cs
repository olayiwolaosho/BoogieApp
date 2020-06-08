using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoogieApp.BoogieFuelme.Views.AuthenticationView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

  

        void SearchBox_Focused(object sender, FocusEventArgs e)
        {
            
            MessagingCenter.Send(this, "Expand");
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
            //bottomSheet.IsVisible = false;
        }

    }
}