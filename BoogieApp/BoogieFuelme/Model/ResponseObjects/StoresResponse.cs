namespace StoresResponseObjects
{
    using BoogieApp.Constants;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    public partial class StoresResponse
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
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("store_owner_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long StoreOwnerId { get; set; }

        [JsonProperty("category_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CategoryId { get; set; }

        [JsonProperty("store_name")]
        public string StoreName { get; set; }

        [JsonProperty("store_img")]
        public string StoreImg { get; set; }

        //[JsonProperty("store_img_path")]
        //public StoreImgPath StoreImgPath { get; set; }
        
        [JsonProperty("store_img_path")]
        public string StoreImgPath { get; set; }

        //[JsonProperty("store_shutter")]
        //public StoreShutter StoreShutter { get; set; } 
        
        [JsonProperty("store_shutter")]
        public string StoreShutter { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updated_on")]
        public DateTimeOffset UpdatedOn { get; set; }

        [JsonProperty("deleted_on")]
        public string DeletedOn { get; set; }

        [JsonProperty("utc_created_on")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UtcCreatedOn { get; set; }

        [JsonProperty("utc_updated_on")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UtcUpdatedOn { get; set; }

        //[JsonProperty("store_status")]
        //public StoreStatus StoreStatus { get; set; }
        
        [JsonProperty("store_status")]
        public string StoreStatus { get; set; }

        //[JsonProperty("username")]
        //public Username Username { get; set; } 
        
        [JsonProperty("username")]
        public string Username { get; set; }

        public string Themainimage
        {
            get
            {
                return $"{ApiConstants.IMAGE_PATH}{StoreImgPath}{StoreImg}";
            }
        }
    }

    public enum StoreImgPath { AssetsImagesStore };

    public enum StoreShutter { Open };

    public enum StoreStatus { Active };

    public enum Username { EstherDanjuma };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                StoreImgPathConverter.Singleton,
                StoreShutterConverter.Singleton,
                StoreStatusConverter.Singleton,
                UsernameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class StoreImgPathConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StoreImgPath) || t == typeof(StoreImgPath?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "/assets/images/store/")
            {
                return StoreImgPath.AssetsImagesStore;
            }
            throw new Exception("Cannot unmarshal type StoreImgPath");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StoreImgPath)untypedValue;
            if (value == StoreImgPath.AssetsImagesStore)
            {
                serializer.Serialize(writer, "/assets/images/store/");
                return;
            }
            throw new Exception("Cannot marshal type StoreImgPath");
        }

        public static readonly StoreImgPathConverter Singleton = new StoreImgPathConverter();
    }

    internal class StoreShutterConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StoreShutter) || t == typeof(StoreShutter?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "open")
            {
                return StoreShutter.Open;
            }
            throw new Exception("Cannot unmarshal type StoreShutter");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StoreShutter)untypedValue;
            if (value == StoreShutter.Open)
            {
                serializer.Serialize(writer, "open");
                return;
            }
            throw new Exception("Cannot marshal type StoreShutter");
        }

        public static readonly StoreShutterConverter Singleton = new StoreShutterConverter();
    }

    internal class StoreStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StoreStatus) || t == typeof(StoreStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "active")
            {
                return StoreStatus.Active;
            }
            throw new Exception("Cannot unmarshal type StoreStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StoreStatus)untypedValue;
            if (value == StoreStatus.Active)
            {
                serializer.Serialize(writer, "active");
                return;
            }
            throw new Exception("Cannot marshal type StoreStatus");
        }

        public static readonly StoreStatusConverter Singleton = new StoreStatusConverter();
    }

    internal class UsernameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Username) || t == typeof(Username?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Esther Danjuma")
            {
                return Username.EstherDanjuma;
            }
            throw new Exception("Cannot unmarshal type Username");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Username)untypedValue;
            if (value == Username.EstherDanjuma)
            {
                serializer.Serialize(writer, "Esther Danjuma");
                return;
            }
            throw new Exception("Cannot marshal type Username");
        }

        public static readonly UsernameConverter Singleton = new UsernameConverter();
    }
}

