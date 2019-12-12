using System;
using viewwerXF.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace viewwerXF
{
    public partial class App : Application
    {
        public static string email { get; set; }
        public static string password { get; set; }
        public static string cookie { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
