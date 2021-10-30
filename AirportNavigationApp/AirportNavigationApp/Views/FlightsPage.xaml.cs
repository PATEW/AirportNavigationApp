using AirportNavigationApp.Models;
using AirportNavigationApp.ViewModels;
using AirportNavigationApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlightsPage : ContentPage
    {

        FlightsViewModel _viewModel;

        public FlightsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new FlightsViewModel();
        }
    }
}