using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.Constants
{
    public static class ApiConstants
    {
        public const string BASE_URL = "https://app.boogie.ng/api";
        public const string API_KEY = "boogie@123_*";
        public const string IMAGE_PATH = "https://app.boogie.ng";

        public const string LOGIN_BASE_URL = BASE_URL + "/User/signin";
        public const string SIGNUP_BASE_URL = BASE_URL + "/User/signup";
        public const string LOCATION_URL = BASE_URL + "/Location/location_list";
        public const string STORELIST = BASE_URL + "/Store/store_list";
        public const string RESETPASSWORD = BASE_URL + "/User/resetPassword";
        public const string FORGOTPASSWORD = BASE_URL + "/User/forgetPassword";
        public const string ORDERCREATE = BASE_URL + "/Items/orderItem";
        public const string ORDERDETAILEDLIST = BASE_URL + "/Items/orderItem_list";
        public const string UPDATEUSER = BASE_URL + "/User/update";
        public const string SENDFEEDBACK = BASE_URL + "/Feedback/feedbackSave";
        public const string FETCHORDERLIST = BASE_URL + "/Items/order_list";
        public const string SAVELIST = BASE_URL + "/User/addList";
        public const string GETLISTNAME = BASE_URL + "/User/listName";
        public const string GETITEMSFROMLIST = BASE_URL + "/User/itemList";
        public const string DELETELIST = BASE_URL + "/User/deleteList";
        public const string GETCATEGORIES = BASE_URL + "/Category/categoryList";
        public const string GETNOTIFICATIONS = BASE_URL + "/Notification/NotificationList";
        public const string GETREWARDPOINTS = BASE_URL + "/Reward/Rewardlist";
        public const string GETMSGLIST = BASE_URL + "/Messages/messagesList";
        public const string GETPRODUCTLIST = BASE_URL + "/Product/ProductList";
        public const string PURCHASEPRODUCT = BASE_URL + "/Reward/purchaseProduct";
        public const string DELETEMESSAGE = BASE_URL + "/Messages/messagesDelete";
        public const string UPDATELOCATION = BASE_URL + "/Location/updateUserLocation";
        public const string ACCEPTORDER = BASE_URL + "/Items/orderStaus";
    }
}
