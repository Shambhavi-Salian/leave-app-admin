using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leave_appz.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Leave_appz.ViewModels;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Leave_appz.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentdayAbsent : ContentPage
    {
        public CurrentdayAbsent()
        {
            InitializeComponent();
            LoadData();
            //   BindingContext = new UserViewModels();
            DateLabel.Text = PickerDate.Date.Date.ToString("dd-MM-yyyy dddd");
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PickerDate.Focus();
        }

        private void PickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = PickerDate.Date.Date.ToString("dd-MM-yyyy dddd");
        }

        async void LoadData()
        {
            var content = "";
            HttpClient client = new HttpClient();
            var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=4&date=" + PickerDate.Date.Date.ToString("yyyy-MM-dd");
            Debug.WriteLine(RestURL);
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);
            
            if (!content.Equals("722"))
            {
                List<User> res = JsonConvert.DeserializeObject<List<User>>(content);
                BindingContext = new UserViewModels(res);
                Debug.WriteLine(content);
            }
          
        }
        //  var Items = JsonConvert.DeserializeObject<List<ItemClass>>(content);
        //  ListView1.ItemsSource = Items;


    

      
    }
 
}