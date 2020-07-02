using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using BoogieApp.Constants;
using BoogieApp.Exceptions;
using BoogieApp.GeneralServices.RequestProvider;
using BoogieApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.AuthenticationService
{
    class AuthService : IAuthenticationService
    {
        private readonly IRequestProvider requestProvider;
        public AuthService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }


        //This is a Post Request
        public async Task<RegistrationResponse> Registration(string user_name, string user_email, string user_mobile, string user_password, string user_address, string user_type, string device_id, long location_id, string user_lat, string user_long, string fcm_token, string drone_delivery, int boogie_vip)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                ["API_KEY"] = ApiConstants.API_KEY,
                ["user_email"] = user_email,
                ["user_pass"] = user_password,
                ["user_name"] = user_name,
                ["user_add"] = user_address,
                ["user_mobile"] = user_mobile,
                ["fcm_token"] = fcm_token,
                ["user_type"] = user_type,
                ["device_id"] = device_id,
                ["location_id"] = location_id,
                ["user_lat"] = user_lat,
                ["user_long"] = user_long,
                ["drone_delivery"] = drone_delivery,
                ["boogie_vip"] = boogie_vip,
            };
            var uri = UriHelper.CombineUri(ApiConstants.SIGNUP_BASE_URL);
            try
            {
                var LocResp = await requestProvider.PostAsync<RegistrationResponse>(uri, pairs);
                return LocResp;
            }
            //If the status of the order has changed before to click cancel button, we will get
            //a BadRequest HttpStatus
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
        }

        public async Task<SignInResponse> SignIn(string user_mobile, string user_password, string fcm_token, string device_id, string user_type, DateTime currentdate)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                ["API_KEY"] = ApiConstants.API_KEY,
                ["user_pass"] = user_password,
                ["email_telephone"] = user_mobile,
                ["fcm_token"] = fcm_token,
                ["user_type"] = user_type,
                ["device_id"] = device_id,
                ["login_type"] = "native",
                ["current_date"] = $"{currentdate}"
            };
            var uri = UriHelper.CombineUri(ApiConstants.LOGIN_BASE_URL);
            try
            {
                var LocResp = await requestProvider.PostAsync<SignInResponse>(uri, pairs);
                return LocResp;
            }
            //If the status of the order has changed before to click cancel button, we will get
            //a BadRequest HttpStatus
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
        }

        public Task<SignInResponse> SignInwithfacebook(string fcm_token, string device_id, string user_type, DateTime currentdate, string login_type, string social_token)
        {
            throw new NotImplementedException();
        }
    }
}
