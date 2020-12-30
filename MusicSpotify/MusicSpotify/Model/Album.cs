using System;
using System.Globalization;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SpotifyAPI.Web;

namespace MusicSpotify.Model
{
    public class Album
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }
        
        [JsonProperty("Image")]
        public Uri Image { get; set; }

        [JsonProperty("AlbumId")]
        public string AlbumId { get; set; }

        [JsonProperty("AlbumSongs")]
        public List<SimpleTrack> AlbumSongs { get; set; }

        [JsonProperty("AlbumArtist")]
        public string AlbumArtist { get; set; }

        public static Album[] FromJson(string json) =>
            JsonConvert.DeserializeObject<Album[]>(json, Converter.Settings);

        public static Album FromSimpleAlbum(SimpleAlbum simpleAlbum, List<SimpleTrack> albumSongs)
        {
            return new Album {
                Name = simpleAlbum.Name,
                ReleaseDate = simpleAlbum.ReleaseDate,
                Image = new Uri(simpleAlbum.Images[0].Url),
                AlbumId = simpleAlbum.Id,
                AlbumSongs = albumSongs,
                AlbumArtist = simpleAlbum.Artists[0].Name
            };
        }
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
