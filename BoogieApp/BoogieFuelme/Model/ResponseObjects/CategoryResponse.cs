using BoogieApp.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.BoogieFuelme.Model.ResponseObjects
{
    public partial class CategoryResponse
    {

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("base_url")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

    }

    public partial class Datum
    {
        [JsonProperty("id")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("location_id")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long LocationId { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("category_description")]
        public string CategoryDescription { get; set; }

        [JsonProperty("category_img")]
        public string CategoryImg { get; set; }

        [JsonProperty("category_img_path")]
        public string CategoryImgPath { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }

        [JsonProperty("deleted_on")]
        public string DeletedOn { get; set; }

        [JsonProperty("utc_created_on")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long UtcCreatedOn { get; set; }

        [JsonProperty("utc_updated_on")]
        public string UtcUpdatedOn { get; set; }

        [JsonProperty("category_status")]
        public string CategoryStatus { get; set; }

        public string Themainimage
        {
            get
            {
                return $"{ApiConstants.IMAGE_PATH}{CategoryImgPath}{CategoryImg}";
            }
        }
    }
}
