using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieFuelme.Model.ResponseObjects
{
    public class LocationResponse
    {
        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Location[] Data { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("id")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }

        [JsonProperty("utc_created_on")]
       // [JsonConverter(typeof(ParseStringConverter))]
        public long UtcCreatedOn { get; set; }

        [JsonProperty("utc_updated_on")]
        public string UtcUpdatedOn { get; set; }

        [JsonProperty("location_status")]
        public string LocationStatus { get; set; }

        [JsonProperty("total_category")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long TotalCategory { get; set; }
    }
}
