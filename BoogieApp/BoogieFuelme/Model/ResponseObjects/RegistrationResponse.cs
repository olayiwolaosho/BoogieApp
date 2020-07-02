using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieFuelme.Model.ResponseObjects
{
    public class RegistrationResponse
    {
        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("id")]
  //      [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("useremail")]
        public string Useremail { get; set; }

        [JsonProperty("login_type")]
        public string LoginType { get; set; }

        [JsonProperty("fcm_token")]
        public string FcmToken { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("user_mobile")]
        public string UserMobile { get; set; }

        [JsonProperty("user_type")]
        public string UserType { get; set; }

        [JsonProperty("user_address")]
        public string UserAddress { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }

        [JsonProperty("reward_point")]
        public string RewardPoint { get; set; }

        [JsonProperty("marketer_id")]
        public string MarketerId { get; set; }

        [JsonProperty("marketer_name")]
        public string MarketerName { get; set; }

        [JsonProperty("utc_created_on")]
   //     [JsonConverter(typeof(ParseStringConverter))]
        public long UtcCreatedOn { get; set; }

        [JsonProperty("utc_updated_on")]
        public string UtcUpdatedOn { get; set; }

        [JsonProperty("user_status")]
        public string UserStatus { get; set; }

        [JsonProperty("location_id")]
    //    [JsonConverter(typeof(ParseStringConverter))]
        public long LocationId { get; set; }

        [JsonProperty("dispatcher_status")]
        public string DispatcherStatus { get; set; }

        [JsonProperty("total_login")]
   //     [JsonConverter(typeof(ParseStringConverter))]
        public long TotalLogin { get; set; }

        [JsonProperty("boogie_vip")]
        public string BoogieVip { get; set; }

        [JsonProperty("subscription_start_utc")]
        public string SubscriptionStartUtc { get; set; }

        [JsonProperty("subscription_end_utc")]
        public string SubscriptionEndUtc { get; set; }

        [JsonProperty("deliveries_count")]
   //     [JsonConverter(typeof(ParseStringConverter))]
        public long DeliveriesCount { get; set; }

        [JsonProperty("drone_delivery")]
        public string DroneDelivery { get; set; }

        [JsonProperty("payment_option_type")]
        public string PaymentOptionType { get; set; }

        [JsonProperty("user_wallet_money")]
   //     [JsonConverter(typeof(ParseStringConverter))]
        public long UserWalletMoney { get; set; }

        [JsonProperty("user_lat")]
        public string UserLat { get; set; }

        [JsonProperty("user_long")]
        public string UserLong { get; set; }

        [JsonProperty("user_image_name")]
        public string UserImageName { get; set; }

        [JsonProperty("user_image_path")]
        public string UserImagePath { get; set; }

        [JsonProperty("full_user_image")]
        public string FullUserImage { get; set; }

        [JsonProperty("location_name")]
        public string LocationName { get; set; }
    }
}



