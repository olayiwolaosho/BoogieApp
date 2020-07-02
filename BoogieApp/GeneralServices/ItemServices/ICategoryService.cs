using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using StoresResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.ItemServices
{
    public interface ICategoryService
    {
        Task<CategoryResponse> categoryResponse(string locationID);

        Task<StoresResponse> storeresponse(long locationID);
    }
}
