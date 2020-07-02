using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.Location
{
    public interface ILocationServices
    {
        Task<LocationResponse> GetAllLocations(Dictionary<string,object> pairs);
    }
}
