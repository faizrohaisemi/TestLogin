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
   
    class ViewTicket
    {
        public async Task<TicketModel.RootObject> UpdateTicket(string url, string token)
        {
            string result;
            try
            {
/*
                string  id = "1" ;
               string tenant_id = "1" ;
                string requester = "Jamal Abdillah Wahad";
                string mesra_link_log_no = "AB1234567";
                string title = "Kerosakan cash drawer";
                string date_created = "2018-11-08T00:00:00";
                string time_created = "2018-11-08T13:00:00";
                string created_by= "1";
*/




                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
/*
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id",  id),
                    new KeyValuePair<string, string>("tenant_id", tenant_id),
                    new KeyValuePair<string, string>("requester",requester),
                    new KeyValuePair<string, string>("mesra_link_log_no", mesra_link_log_no),
                    new KeyValuePair<string, string>("title",title),
                    new KeyValuePair<string, string>("date_created", date_created),
                    new KeyValuePair<string, string>("time_created",time_created),
                    new KeyValuePair<string, string>("created_by", created_by)

                });
*/

                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                result = await responseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                return null;
            }
            TicketModel.RootObject data = JsonConvert.DeserializeObject<TicketModel.RootObject>(result);
              Debug.WriteLine(data);
            return data;
          


        }

        internal Task GoLogin(string url, string token)
        {
            throw new NotImplementedException();
        }
    }
}
