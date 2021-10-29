using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace AirportNavigationApp.Droid
{

    [Activity(Label = "TRP", Theme = "@style/Splash", MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}