using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestLogin.Model;

namespace TestLogin.Controller
{
    class ViewUserCtrl
    {
        public async Task<UserListModel.RootObject> GetUser(string url, string token)
        {
            string result;
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                result = await responseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                return null;
            }

            UserListModel.RootObject data = JsonConvert.DeserializeObject<UserListModel.RootObject>(result);

            return data;

        }

        internal Task GoLogin(string url, string token)
        {
            throw new NotImplementedException();
        }
    }
}
