using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirportNavigationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        // Initialize SettingsPage
        public SettingsPage()
        {
            InitializeComponent();
        }

        // Update user viewed instructions when picker index is changed
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem; // This is the model selected in the picker
            if (selectedItem.ToString().Equals("Ticket Page"))
            {
                ticketInstructions();
            }
            else if (selectedItem.ToString().Equals("Checklist Page"))
            {
                checklistInstructions();
            }
            else if (selectedItem.ToString().Equals("Map Page"))
            {
                mapInstructions();
            }
            else if (selectedItem.ToString().Equals("Flights Page"))
            {
                flightInstructions();
            }
        }

        public void ticketInstructions() {
            instructionsView.Children.Clear();

            Label text = new Label
            {
                Text =
                "\u2022 Ticket page is the first step in the TRP process.\n\n" +
                "\u2022 Start on the ticket page by selecting your departure\n\tairport.\n\n" +
                "\u2022 Input your four digit flight number and select enter.\n\n" +
                "\u2022 If you have submitted a valid flight number for the\n\tselected airport, information about the flight will be\n\tdisplayed in the table below.\n\n" +
                "\u2022 After completing ticket page, continue to map page.\n\n",
                TextColor = Color.FromHex("#FFFFFF"),
                FontSize = 15,
            };

            instructionsView.Children.Add(text);
        }

        public void checklistInstructions()
        {
            instructionsView.Children.Clear();

            Label text = new Label
            {
                Text =
                "\u2022 Checklist page is the second step in the TRP process\n\n" +
                "\u2022 Several tasks essential to travel are automatically\n\tdisplayed on the checklist page in chronological order.\n\n" +
                "\u2022 Custom tasks can be added by typing the new task\n\tname in the add custom text box and selecting add.\n\n" +
                "\u2022 The checklist page is intended to be used in conjunction\n\twith the map page by locating and navigating to the\n\tenumerated tasks on the map.\n\n",
                TextColor = Color.FromHex("#FFFFFF"),
                FontSize = 15,
            };

            instructionsView.Children.Add(text);
        }

        public void mapInstructions()
        {
            instructionsView.Children.Clear();

            Label text = new Label
            {
                Text =
                "\u2022 Map page is the third step in the TRP process\n\n" +
                "\u2022 After a user has input their departure airport, an\n\tinteractive map of that airpot will be displayed here.\n\n" +
                "\u2022 The map contains information about the airport in blue\n\tpins and checklist items in red pins.\n\n" +
                "\u2022 Complete checklist items by navigating to their marked\n\tlocation in the airport and completing their specified\n\ttasks.\n\n" +
                "\u2022 Airport map views are automatically switched by\n\tselecting map pins that lead to a new area of the airport.\n\n",
                TextColor = Color.FromHex("#FFFFFF"),
                FontSize = 15,
            };

            instructionsView.Children.Add(text);
        }

        public void flightInstructions()
        {
            instructionsView.Children.Clear();

            Label text = new Label
            {
                Text =
                "\u2022 Flights page contains extra information and is not a part\n\tof the TRP process\n\n" +
                "\u2022 After a user has input their departure airport, all flights\n\tleaving that airpot will be displayed here.\n\n" +
                "\u2022 Flights are displayed on the page in groups of 30\n\tordered by departure time.\n\n" +
                "\u2022 Select the next button at the bottom of the page to view\n\tthe next group of 30 flights.\n\n" +
                "\u2022 Select the previous button at the bottom of the page to\n\tview the previous group of 30 flights\n\n",
                TextColor = Color.FromHex("#FFFFFF"),
                FontSize = 15,
            };

            instructionsView.Children.Add(text);
        }
    }
}