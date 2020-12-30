using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MusicSpotify.View;

namespace MusicSpotify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            ((NavigationPage)Current.MainPage).BarBackgroundColor = Color.FromHex("1db954");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
