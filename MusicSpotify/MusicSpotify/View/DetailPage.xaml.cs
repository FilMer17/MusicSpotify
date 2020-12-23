using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MusicSpotify.Model;
using MusicSpotify.ViewModel;

namespace MusicSpotify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        public DetailPage(Album album)
        {
            InitializeComponent();
            BindingContext = new AlbumDetailViewModel(album);
        }
    }
}