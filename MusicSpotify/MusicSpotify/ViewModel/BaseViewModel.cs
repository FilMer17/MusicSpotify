using System;
using System.Timers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Essentials;

namespace MusicSpotify.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                WifiConnection = "Wifi.png";
            }
            else
            {
                WifiConnection = "NoWifi.png";
            }
            var timerWifi = new Timer(10000);
            timerWifi.AutoReset = true;
            timerWifi.Elapsed += TimerWifi_Elapsed;
            timerWifi.Start();
        }

        private void TimerWifi_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                WifiConnection = "Wifi.png";
            }
            else
            {
                WifiConnection = "NoWifi.png";
            }
        }

        string title;
        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                {
                    return;
                }

                title = value;
                OnPropertyChanged();
            }
        }

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                {
                    return;
                }

                isBusy = value;
                OnPropertyChanged();
            }
        }

        string wifiConnection;
        public string WifiConnection
        {
            get => wifiConnection;
            set
            {
                if (wifiConnection == value)
                {
                    return;
                }

                wifiConnection = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
