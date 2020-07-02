using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.Constants;
using BoogieApp.Exceptions;
using BoogieApp.GeneralServices.RequestProvider;
using BoogieApp.Helpers;
using StoresResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.ItemServices
{
    public class CategoryService : ICategoryService
    {

        private readonly IRequestProvider requestProvider;

        public CategoryService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }


        public async Task<CategoryResponse> categoryResponse(string locationID)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                ["API_KEY"] = ApiConstants.API_KEY,
                ["location_id"] = locationID,
            };
            var uri = UriHelper.CombineUri(ApiConstants.GETCATEGORIES);
            try
            {
                var LocResp = await requestProvider.PostAsync<CategoryResponse>(uri, pairs);
                return LocResp;
            }
            //If the status of the order has changed before to click cancel button, we will get
            //a BadRequest HttpStatus
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
        }

        public async Task<StoresResponse> storeresponse(long locationID)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                ["API_KEY"] = ApiConstants.API_KEY,
                ["category_id"] = locationID,
            };
            var uri = UriHelper.CombineUri(ApiConstants.STORELIST);
            try
            {
                var LocResp = await requestProvider.PostAsync<StoresResponse>(uri, pairs);
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
