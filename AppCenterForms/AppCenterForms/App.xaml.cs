using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using static AppCenterForms.AppSecrets;

namespace AppCenterForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ButtonPage();
            //MainPage = new NewSolutionPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start(
                $"ios={AppCenterSecret_iOS};" +
                $"android={AppCenterSecret_Android};" +
                $"uwp={AppCenterSecret_UWP};",
                typeof(Analytics),
                typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
