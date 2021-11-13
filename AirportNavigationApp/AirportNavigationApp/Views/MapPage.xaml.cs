using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    public partial class MapPage : ContentPage
    {
        public string viewMessage = "You are viewing the map for: " + App._Airport;
        public string airport = App._Airport;

        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewMessage = "You are viewing the map for: " + App._Airport;
        }

        public string ViewMessage
        {
            get { return viewMessage; }
            set
            {
                viewMessage = value;
                OnPropertyChanged(nameof(ViewMessage));
            }
        }

        public string Airport
        {
            get { return airport; }
            set
            {
                airport = value;
                OnPropertyChanged(nameof(Airport));
            }
        }
    }
}
