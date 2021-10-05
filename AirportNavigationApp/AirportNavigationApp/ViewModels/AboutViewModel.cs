using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AirportNavigationApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://discord.gg/zg8XGtMx"));
        }

        public ICommand OpenWebCommand { get; }
    }
}