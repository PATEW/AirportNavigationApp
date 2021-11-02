using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AirportNavigationApp.ViewModels
{
    public class TicketViewModel : BaseViewModel
    {
        public TicketViewModel()
        {
            Title = "Ticket Information";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://discord.gg/zg8XGtMx"));
        }

        public ICommand OpenWebCommand { get; }
    }
}