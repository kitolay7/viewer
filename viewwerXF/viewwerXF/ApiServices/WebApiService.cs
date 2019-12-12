using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using viewwerXF.Models;

namespace viewwerXF.ApiServices
{
    class WebApiService
    {
        public static readonly string BaseURL = "https://dev.viewwer.com";

        public static Uri CookieURI { get { return new Uri(BaseURL); } }

        private static HttpClient _httpClient;
        private HttpClientHandler HttpClientHandler;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public WebApiService()
        {
            HttpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };
            _httpClient = new HttpClient(HttpClientHandler);
            _httpClient.Timeout = TimeSpan.FromMilliseconds(100000);
        }

        public CookieContainer Cookies
        {
            get { return HttpClientHandler.CookieContainer; }
            set { HttpClientHandler.CookieContainer = value; }
        }

        public CookieCollection GetCookies()
        {
            return Cookies.GetCookies(CookieURI);
        }

        public void AddCookies(string cookieString)
        {
            var cookies = JsonConvert.DeserializeObject<List<Cookie>>(cookieString);


            foreach (Cookie cookie in cookies)
            {
                Cookies.Add(WebApiService.CookieURI, cookie);
            }
        }

        public BaseResponse Authorize(string username, string password)
        {
            var contentObject = new BaseResponse();

            var url = $"{BaseURL}/api/user/auth";
            var body = $"{{\"email\":\"{username}\",\"password\":\"{password}\"}}";
            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var contentString = response.Content.ReadAsStringAsync().Result;

                contentObject = JsonConvert.DeserializeObject<BaseResponse>(contentString);
            }

            return contentObject;
        }


        public List<Tour> GetMyTours()
        {
            var response = this.GetList<List<Tour>>($"{BaseURL}/api/tours/list");
            return response;
        }

        public T GetList<T>(string url /*, Dictionary<string, string> headers = null*/) where T : new()
        {
            lock (_httpClient)
            {
                var contentObject = new T();

                try
                {
                    /*if (headers != null && headers.Count > 0)
					{
						foreach (var header in headers)
						{
							_httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
						}
					}*/

                    //   LogRequest(url, _httpClient.DefaultRequestHeaders.ToString());

                    var getResult = _httpClient.GetAsync(url).Result;
                    if (getResult.IsSuccessStatusCode)
                    {
                        var contentString = getResult.Content.ReadAsStringAsync().Result;
                        try
                        {
                            contentObject = JsonConvert.DeserializeObject<T>(contentString);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex);
                            contentObject = new T();
                        }
                        // LogResponse(contentString);
                    }
                    else
                    {
                        throw new Exception(getResult.StatusCode.ToString());
                    }
                }
                //ncrunch: no coverage start
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                return contentObject;
            }
        }
    }
}
