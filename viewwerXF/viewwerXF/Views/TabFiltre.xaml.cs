using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using viewwerXF.ApiServices;
using viewwerXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace viewwerXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabFiltre : ContentPage
    {
        WebApiService api = new WebApiService();
        public TabFiltre()
        {
            InitializeComponent();
          //  BindingContext = new TourViewModel(api);
            var vm = new TourViewModel(api);
            this.BindingContext = vm;
        }

        private async void onItemSelected(Object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            // ((ListView)sender).SelectedItem = null;
          //  Application.Current.MainPage = new NavigationPage(new ListePage());
           // await NavigationPage.PushAsync(new TabFavoris());
            await Navigation.PushAsync(new ListePage());
        }

        private async void onClickImage(object sender, EventArgs args)
        {
           // await Navigation.PushAsync(new ListePage());
            await Navigation.PushAsync(new ListePage());
        }
    }
}