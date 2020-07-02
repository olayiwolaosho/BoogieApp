using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoogieApp.GeneralServices.DependencyService;
using BoogieApp.iOS.DependencyService;
using Foundation;
using Security;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(IOSDevice))]
namespace BoogieApp.iOS.DependencyService
{
    class IOSDevice : IDevice
    {
        public string GetIdentifier()
        {
            var query = new SecRecord(SecKind.GenericPassword);
            query.Service = NSBundle.MainBundle.BundleIdentifier;
            query.Account = "UniqueID";

            NSData uniqueId = SecKeyChain.QueryAsData(query);
            if (uniqueId == null)
            {
                query.ValueData = NSData.FromString(System.Guid.NewGuid().ToString());
                var err = SecKeyChain.Add(query);
                if (err != SecStatusCode.Success && err != SecStatusCode.DuplicateItem)
                    throw new Exception("Cannot store Unique ID");

                return query.ValueData.ToString();
            }
            else
            {
                return uniqueId.ToString();
            }
        }
    }
}