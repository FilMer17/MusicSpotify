using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace MusicSpotify.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

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

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
