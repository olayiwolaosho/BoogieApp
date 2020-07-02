using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.Constants;
using BoogieApp.Exceptions;
using BoogieApp.GeneralServices.RequestProvider;
using BoogieApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.Location
{
    public class LocationServices : ILocationServices
    {
        private readonly IRequestProvider requestProvider;

        public LocationServices(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider; 
        }

        //The name is Get but it is actually calling a post request method
        public async Task<LocationResponse> GetAllLocations(Dictionary<string, object> pairs)
        {
            var uri = UriHelper.CombineUri(ApiConstants.LOCATION_URL);
            try
            {
               var LocResp = await requestProvider.PostAsync<LocationResponse>(uri,pairs);
                return LocResp;
            }
            //If the status of the order has changed before to click cancel button, we will get
            //a BadRequest HttpStatus
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
        }
    }
    
}
