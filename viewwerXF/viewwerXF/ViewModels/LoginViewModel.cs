using viewwerXF.ApiServices;
using viewwerXF.Models;
using viewwerXF.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace viewwerXF.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public Action DisplayInvalidLoginPrompt;
        public Action DisplaySuccesLoginPrompt;
        WebApiService api = new WebApiService();

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("txtEmail"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("txtPassword"));
            }
        }
        public ICommand LoginCommand { protected set; get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnSubmit);
        }


        public void OnSubmit()
        {
            var result = this.Authorize(email, password);

            if (result.IsSuccess)
            {
                string cookies = this.GetCookies();

                Application.Current.Properties.Clear();
                Application.Current.Properties.Add("cookie", cookies.ToString());
                Application.Current.Properties.Add("email", email);
                Application.Current.Properties.Add("password", password);

                App.email = email;
                App.password = password;
                App.cookie = cookies.ToString();


                List<Tour> tours = api.GetMyTours();

                Application.Current.MainPage = new NavigationPage(new TabsPage());


            }
            else
            {
                if (result.ErrorMessage.IsNull())
                {
                    DisplayInvalidLoginPrompt();
                }
                else
                {
                    DisplayInvalidLoginPrompt();
                }
            }
            //loading.Hidden = true;
            // loading.DisposeEx();

        }
     

        public AuthorizeResult Authorize(string username, string password)
        {
            var result = api.Authorize(username, password);
            return new AuthorizeResult()
            {
                IsSuccess = result.IsSuccess(),
                ErrorMessage = result.Error
            };
        }

        public string GetCookies()
        {
            var cookies = api.GetCookies();
            List<Cookie> cookieList = new List<Cookie>();
            foreach (Cookie cookie in cookies)
            {
                cookieList.Add(cookie);
            }
            var cookieString = cookieList.ToJson();
            return cookieString;
        }

        public class AuthorizeResult
        {
            public string ErrorMessage { get; set; }
            public bool IsSuccess { get; set; }
        }
    }
}
