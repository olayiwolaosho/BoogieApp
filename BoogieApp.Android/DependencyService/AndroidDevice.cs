using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BoogieApp.Droid.DependencyService;
using BoogieApp.GeneralServices.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDevice))]
namespace BoogieApp.Droid.DependencyService
{
    class AndroidDevice : IDevice
    {
        public string GetIdentifier()
        {
            return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }
    }
}