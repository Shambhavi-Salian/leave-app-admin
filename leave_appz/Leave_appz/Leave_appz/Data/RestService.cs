using JsonModelClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Leave_appz.Data
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async void PostRequest(string URL, UserDataModel userDataModel)
        {
            Leave_appzPage leaveAppzPage = new Leave_appzPage();
            System.Diagnostics.Debug.WriteLine("asa");
            var formContent = new FormUrlEncodedContent(new[]
                {
               new KeyValuePair<string, string>("id", "1"),
               new KeyValuePair<string, string>("useremail", userDataModel.email_id),
               new KeyValuePair<string, string>("password", userDataModel.user_password),
           });

            //var myHttpClient = new HttpClient();
            var response = await client.PostAsync(URL, formContent);

            var json = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(json);

            var userModel = JsonConvert.DeserializeObject<JsonModelClass.UserDataModel>(json);
            leaveAppzPage.CompareCredentials(userModel);
                

        }
    }
}

