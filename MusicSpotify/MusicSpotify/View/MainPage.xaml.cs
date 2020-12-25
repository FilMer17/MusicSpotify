using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

using MusicSpotify.Model;
using MusicSpotify.ViewModel;

namespace MusicSpotify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AlbumsViewModel();
        }

        async void ListVeiw_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Album album))
            {
                return;
            }

            await Navigation.PushAsync(new DetailPage(album));

            ((ListView)sender).SelectedItem = null;
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection is Album album))
            {
                return;
            }

            await Navigation.PushAsync(new DetailPage(album));

            ((ListView)sender).SelectedItem = null;
        }
    }
}