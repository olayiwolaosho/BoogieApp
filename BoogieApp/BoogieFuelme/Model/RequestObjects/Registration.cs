using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieFuelme.Model.RequestObjects
{
    class Registration
    {
        [JsonProperty("user_email")]
        public string user_email { get; set; }

        [JsonProperty("user_pass")]
        public string user_password { get; set; }

        [JsonProperty("user_name")]
        public string user_name { get; set; }

        [JsonProperty("user_add")]
        public string user_address { get; set; }

        [JsonProperty("user_mobile")]
        public string user_mobile { get; set; }

        [JsonProperty("fcm_token")]
        public string fcm_token { get; set; }

        [JsonProperty("user_type")]
        public string user_type { get => "customer"; }

        [JsonProperty("API_KEY")]
        public string API_KEY { get; set; }

        [JsonProperty("device_id")]
        public string device_id { get; set; }

        [JsonProperty("location_id")]
        public string location_id { get; set; }

        [JsonProperty("user_lat")]
        //  [JsonConverter(typeof(ParseStringConverter))]
        public long UserLat { get; set; }

        [JsonProperty("user_long")]
        //   [JsonConverter(typeof(ParseStringConverter))]
        public long UserLong { get; set; }
    }

    
}
