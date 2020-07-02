using BoogieApp.BoogieFuelme.Model.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoogieApp.GeneralServices.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> Registration(string user_name, string user_email, string user_mobile, string user_password,
            string user_address, string user_type, string device_id, long location_id, string user_lat, string user_long,
            string fcm_token, string drone_delivery, int boogie_vip);

        Task<SignInResponse> SignIn(string user_mobile, string user_password, string fcm_token, string device_id, string user_type, DateTime currentdate);
        Task<SignInResponse> SignInwithfacebook(string fcm_token, string device_id, string user_type, DateTime currentdate, string login_type, string social_token);



        //d0wHQYJaqkQ:APA91bHBg-WlqxmGHlB1L4mGhaJ38bVG9u1xHSSFEyVDpyOBIQIc1EfFGv1SRpIRwLCr33XYMXHGR7nkOjnf

        //2714145165267028





    }
}
