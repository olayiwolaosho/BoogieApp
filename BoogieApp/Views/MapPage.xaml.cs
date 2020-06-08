using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BoogieApp.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            Map map = new Map();
            Content = map;

            
        }
    }
}
