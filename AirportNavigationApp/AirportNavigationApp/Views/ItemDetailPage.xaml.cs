using AirportNavigationApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AirportNavigationApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}