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

namespace MusicSpotify.ViewModel
{
    public class AlbumsViewModel : BaseViewModel
    {
        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Album> Albums { get; }
        public List<string> Authors { get; }
        public string AuthorSelected { get; set; }
        public Command GetAlbumsCommand { get; }

        public AlbumsViewModel()
        {
            Title = "Music with Spotify";
            Albums = new ObservableCollection<Album>();
            Authors = new List<string> { "Kygo", "Ed Sheeran", "Tylor Swift" };
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

                var json = await Client.GetStringAsync("https://montemagno.com/monkeys.json");
                var albums = Album.FromJson(json);

                Albums.Clear();
                foreach (var album in albums)
                {
                    Albums.Add(album);
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
