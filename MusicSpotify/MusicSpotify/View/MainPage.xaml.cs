﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}