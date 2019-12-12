using viewwerXF.ApiServices;
using viewwerXF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace viewwerXF.ViewModels
{
    class TourViewModel : INotifyPropertyChanged
    {
        WebApiService api = new WebApiService();
        //public DelegateCommand EditAddressCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public static CookieContainer CookieContainer = new CookieContainer();
        //int taps = 0;
      

        private ObservableCollection<Tour> items;
        public ObservableCollection<Tour> Items
        {
            get { return items; }
            set
            {

                items = value;
            }

        }
        ICommand tapCommand;
        public TourViewModel(WebApiService apiService)
        {
            api = apiService;
            tapCommand = new Command(OnTapped);
          //  var cooki = Application.Current.Properties["cookie"] as string;
            

            var email = App.email; //Application.Current.Properties["email"] as string;
            var password = App.password; //Application.Current.Properties["password"] as string;

            // api.AddCookies(cooki);


            var result = api.Authorize(email, password);

            if (result.IsSuccess())
            {
                loadData();
            }

         //   List<Tour> tours = api.GetMyTours();
        
        }

        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        void OnTapped(object s)
        {
            //taps++;
            Debug.WriteLine("parameter: " + s);
        }
        //region INotifyPropertyChanged code omitted



        public void loadData()
        {
            List<Tour> tours = api.GetMyTours();
            Items = new ObservableCollection<Tour>() { };
            Tour result = new Tour();
            foreach (Tour item in tours)
            {

                result = new Tour()
                {
                    Name = item.Description,
                    // Url2 = item.FullUrl 
                    //new Entity()
                    //{

                    //};
                    ProductImage = new Uri("https://upload.wikimedia.org/wikipedia/en/5/5f/Original_Doge_meme.jpg")

                    //  Url = item.ThumbnailUrl 
                };


                items.Add(result);

            }
        }
    }
}
