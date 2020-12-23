using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MusicSpotify.Model
{
    public class Album
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        public static Album[] FromJson(string json) =>
            JsonConvert.DeserializeObject<Album[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Album[] self) => 
            JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
