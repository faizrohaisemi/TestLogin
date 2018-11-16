using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestLogin.Model;
using Xamarin.Forms;

namespace TestLogin.Controller
{
    class Loginctrl
    {
        public async Task<string> GoLogin (string url, string email, string password)
        {
            string result;
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username",email),
                    new KeyValuePair<string, string>("password", password),
                });
                HttpResponseMessage responseMessage = await httpClient.PostAsync(url, formContent);
                result = await responseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(result);
            }
            catch (Exception e) {
                return null;
            }

            var data = JsonConvert.DeserializeObject<User.RootObject>(result);
            Debug.WriteLine(data.data.token);

            if (Application.Current.Properties.ContainsKey("login_token"))
                    {
                Application.Current.Properties["login_token"] = data.data.token;}
            else { Application.Current.Properties.Add("login_token", data.data.token);
            }

            await Application.Current.SavePropertiesAsync();

            return result;
            
        }

        internal Task GoLogin(string url, object username, object password)
        {
            throw new NotImplementedException();
        }
    }
}
