using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCenterForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonPage : ContentPage
    {
        public ButtonPage()
        {
            InitializeComponent();
        }

        async void Crash_Clicked(object sender, EventArgs e)
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception exception) {
                var properties = new Dictionary<string, string> {
                    { "Category", "Music" },
                    { "Wifi", "On" }
                };
                Crashes.TrackError(exception, properties);
            }

            var crash = await DisplayAlert("The app will close",
                "A crash report will be sent when you reopen the app", "Crash app",
                "Cancel");
            if (crash)
            {
                Crashes.GenerateTestCrash();
            }
        }

        public void Event_Clicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Sample event");
            DisplayAlert(null, "Event sent.", null, "OK");
        }

        async void Color_Clicked(object sender, EventArgs e)
        {
            var color = await DisplayActionSheet("Send event with color property", null,
                null, "Yellow", "Blue", "Red");
            if (color.Equals("Yellow"))
            {
                Analytics.TrackEvent("Color event", new Dictionary<string, string>
                {
                    { "Color", "Yellow" }
                });
            }
            else if (color.Equals("Blue"))
            {
                Analytics.TrackEvent("Color event", new Dictionary<string, string>
                {
                    { "Color", "Blue" }
                });
            }
            else if (color.Equals("Red"))
            {
                Analytics.TrackEvent("Color event", new Dictionary<string, string>
                {
                    { "Color", "Red" }
                });
            }
        }
    }
}
