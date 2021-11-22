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
    public partial class CheckListPage : ContentPage
    {

        public Grid checklist;
        public List<string> checklistItems;

        public CheckListPage()
        {
            InitializeComponent();
            BindingContext = this;

            CreateChecklist();
        }

        public void CreateChecklist()
        {
            checklist = new Grid();
            checklistItems = new List<string>();

            checklistItems.Add("Park at Airport");
            checklistItems.Add("Arrive at Airport Door");
            checklistItems.Add("Check in at Ticket Counter");
            checklistItems.Add("Check Bags at Ticket Counter");
            checklistItems.Add("Navigate to Terminal");
            checklistItems.Add("Navigate to Gate");
            checklistItems.Add("Wait for Boarding Group to be Called");
            checklistItems.Add("Board Plane");

            for (int i = 0; i < checklistItems.Count; i++)
            {

                var arrivedLabel = new Label
                {
                    Text = checklistItems[i],
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 20,
                    TextColor = Color.White,
                };
                checklist.Children.Add(arrivedLabel, 1, i);

                CheckBox checkBox = new CheckBox
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Color = Color.FromHex("#00A9CD"),
                };
                checkBox.CheckedChanged += onCheck;
                checklist.Children.Add(checkBox, 0, i);
            }
            Checklist.Content = checklist;
        }

        public void onCheck(object sender, EventArgs e) {

        }
    }
}