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
        public Entry newItem;

        public CheckListPage()
        {
            InitializeComponent();
            BindingContext = this;

            CreateChecklist();
        }

        public void CreateChecklist()
        {

            checklist = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(0.85, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) },
                },
                ColumnSpacing = 0,
                RowSpacing = 0,
            };

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
                    Text = " " + (i+1) + ". " + checklistItems[i],
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 20,
                    TextColor = Color.White,
                    Padding = new Thickness(0, 10, 0, 10),
                };
                checklist.Children.Add(arrivedLabel, 0, i);

                CheckBox checkBox = new CheckBox
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Color = Color.FromHex("#00A9CD"),
                };
                checkBox.CheckedChanged += onCheck;
                checklist.Children.Add(checkBox, 1, i);

                BoxView border = new BoxView {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End ,
                };
                BoxView border1 = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.White,
                    VerticalOptions = LayoutOptions.End,
                };
                checklist.Children.Add(border, 0, i);
                checklist.Children.Add(border1, 1, i);
            }
            addItemRow();

            Checklist.Content = checklist;
        }

        public void addItemRow()
        {
            newItem = new Entry
            {
                Placeholder = "Add A Custom Item",
                PlaceholderColor = Color.White,
                TextColor = Color.White,
                FontSize = 20,
                Margin = new Thickness(25, 10, 0, 10),

            };
            Button newItemButton = new Button
            {
                Text = "Add",
            };
            newItemButton.Clicked += newItemButtonClicked;
            checklist.Children.Add(newItem, 0, checklistItems.Count);
            checklist.Children.Add(newItemButton, 1, checklistItems.Count);

            BoxView border2 = new BoxView
            {
                HeightRequest = 1,
                Color = Color.White,
                VerticalOptions = LayoutOptions.End,
            };
            BoxView border3 = new BoxView
            {
                HeightRequest = 1,
                Color = Color.White,
                VerticalOptions = LayoutOptions.End,
            };
            checklist.Children.Add(border2, 0, checklistItems.Count);
            checklist.Children.Add(border3, 1, checklistItems.Count);
        }

        private void newItemButtonClicked(object sender, EventArgs e)
        {
            checklistItems.Add(newItem.Text);
            checklist.Children.RemoveAt(checklist.Children.Count - 3);
            checklist.Children.RemoveAt(checklist.Children.Count - 3);

            var arrivedLabel = new Label
            {
                Text = newItem.Text,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.White,
                Padding = new Thickness(25, 10, 0, 10),
            };
            checklist.Children.Add(arrivedLabel, 0, checklistItems.Count - 1);

            CheckBox checkBox = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Color = Color.FromHex("#00A9CD"),
            };
            checkBox.CheckedChanged += onCheck;
            checklist.Children.Add(checkBox, 1, checklistItems.Count - 1);

            addItemRow();
        }

        public void onCheck(object sender, EventArgs e) {

        }
    }
}