using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        private double startScale;
        private double currentScale;
        private double xOffset;
        private double yOffset;
        public double scaleCurrent = 0.5;

        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;


        }

        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {

            if (e.Status == GestureStatus.Started)
            {
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);
                Content.TranslationX = Math.Min(0, Math.Max(targetX, -Content.Width * (currentScale - 1)));
                Content.TranslationY = Math.Min(0, Math.Max(targetY, -Content.Height * (currentScale - 1)));
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }


        private void ZoomInClicked(object sender, EventArgs args)
        {
            if (scaleCurrent <= 2)
            {
                scaleCurrent = scaleCurrent + 0.5;
            }
            else
            {
                scaleCurrent = scaleCurrent;
            }



        }

        private void ZoomOutClicked(object sender, EventArgs args)
        {
            if (scaleCurrent >= 1)
            {
                scaleCurrent = scaleCurrent - 0.5;
            }
            else
            {
                scaleCurrent = scaleCurrent;
            }

        }

        public double ScaleCurrent
        {
            get { return scaleCurrent; }
            set
            {
                scaleCurrent = value;

            }
        }





        private void Button_Clicked(object sender, EventArgs e)
        {
            if (scaleCurrent >= 1)
            {
                scaleCurrent = scaleCurrent - 0.5;
            }
            else
            {
                scaleCurrent = scaleCurrent;
            }
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {

        }
    }
}
