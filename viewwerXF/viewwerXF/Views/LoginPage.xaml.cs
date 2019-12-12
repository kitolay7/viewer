using viewwerXF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace viewwerXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //MyImage.Source = ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/en/5/5f/Original_Doge_meme.jpg"));
            //MyImage.Source = new UriImageSource()
            //{
            //    Uri = new Uri("https://upload.wikimedia.org/wikipedia/en/5/5f/Original_Doge_meme.jpg")
            //};
          //  MyImage.Source = ImageSource.FromFile("logo.png");
            //MyImage.Source = new UriImageSource
            //{
            //    Uri = new Uri("https://upload.wikimedia.org/wikipedia/en/5/5f/Original_Doge_meme.jpg"),
            //    CachingEnabled = true,
            //    CacheValidity = new TimeSpan(5, 0, 0, 0)
            //};

            var image = new Image();

            //will use SecuredImageLoaderSourceHandler  
           // image.Source = new SecuredUriImageSource("https://blabla.com/upload/image123.jpg");


            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.DisplaySuccesLoginPrompt += () => DisplayAlert("Succes", "Succes, Authentificatin", "OK");

            txtEmail.Completed += (object sender, EventArgs e) =>
            {
                txtEmail.Focus();
            };

            txtPassword.Completed += (object sender, EventArgs e) =>
            {
                vm.LoginCommand.Execute(null);
            };

        }
    }
}