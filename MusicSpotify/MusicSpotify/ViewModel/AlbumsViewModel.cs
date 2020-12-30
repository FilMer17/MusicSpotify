using System;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Essentials;

using MusicSpotify.Model;
using MusicSpotify.Service;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace MusicSpotify.ViewModel
{
    public class AlbumsViewModel : BaseViewModel
    {
        //HttpClient httpClient;
        //HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Album> Albums { get; }
        public Dictionary<string, string> Authors { get; }
        public List<string> AuthorsNames { get; }
        public string AuthorSelected { get; set; }
        public Command GetAlbumsCommand { get; }

        private readonly string clientId ="e260c04c8d644b239d8ffc02b3b90a3a";
        private readonly string clientSecret = "e57e3550d7074d57ae8d2a5698a41c69";

        public AlbumsViewModel()
        {
            Title = "Music with Spotify";
            AuthorSelected = "Kygo";
            Albums = new ObservableCollection<Album>();
            Authors = new Dictionary<string, string>
            {
                { "Kygo", "23fqKkggKUBHNkbKtXEls4" },
                { "Ed Sheeran", "6eUKZXaKkcviH0Ku9w2n3V" },
                { "Tylor Swift", "06HL4z0CvFAxyc27GXpf02" }
            };
            AuthorsNames = Authors.Keys.ToList();
            GetAlbumsCommand = new Command(async () => await GetAlbumsAsync());
        }

        async Task GetAlbumsAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var config = SpotifyClientConfig.CreateDefault();
                var request = new ClientCredentialsRequest(clientId, clientSecret);
                var response = await new OAuthClient(config).RequestToken(request);
                var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

                var albumsRaw = await spotify.Artists.GetAlbums(Authors[AuthorSelected]);
                
                var albums = albumsRaw.Items;
                Albums.Clear();
                foreach (var album in albums)
                {
                    var songsRaw = await spotify.Albums.GetTracks(album.Id);
                    var songs = songsRaw.Items;

                    Albums.Add(Album.FromSimpleAlbum(album, songs));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error to get albums: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error with albums! ", ex.Message, "Dobrá");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
