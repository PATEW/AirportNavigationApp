using AirportNavigationApp.Services;
using AirportNavigationApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp
{
    public partial class App : Application
    {

        public static string _Airport { get; set; } = "Hello";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
