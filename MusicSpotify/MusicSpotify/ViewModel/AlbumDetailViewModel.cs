using System;

using Xamarin.Essentials;
using Xamarin.Forms;

using MusicSpotify.Model;

using SpotifyAPI.Web;

namespace MusicSpotify.ViewModel
{
    public class AlbumDetailViewModel : BaseViewModel
    {
        Album album;
        public Album Album
        {
            get => album;
            set
            {
                if (album == value)
                {
                    return;
                }

                album = value;
                OnPropertyChanged();
            }
        }
        SimpleTrack AlbumSimpleTrack = new SimpleTrack();

        public AlbumDetailViewModel()
        {

        }

        public AlbumDetailViewModel(Album album)
        {
            Album = album;
        }

    }
}
