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
using Plugin.Connectivity;

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
            var validator = new Validator();
            validator.dateSelectedTrue(PickerDate.Date.Date.ToString("yyyy-MM-dd"));
        }
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PickerDate.Focus();
        }

        private void PickerDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = PickerDate.Date.Date.ToString("dd-MM-yyyy dddd");
            try
            {
                var progress_parent = this.FindByName<AbsoluteLayout>("progress_parent");
                progress_parent.IsVisible = true;
                var listView = this.FindByName<ListView>("listview");
                var no_data = this.FindByName<AbsoluteLayout>("no_data");
                no_data.IsVisible = false;


                listView.IsVisible = false;
            }
            catch(Exception e1)
            {
                
            }

            LoadData();
        }

        async void LoadData()
        {
           // if (CrossConnectivity.Current.IsConnected)
           // {
                try
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
                var progress_parent = this.FindByName<AbsoluteLayout>("progress_parent");
                progress_parent.IsVisible = false;
                var listView = this.FindByName<ListView>("listview");
                var no_data = this.FindByName<AbsoluteLayout>("no_data");
                var validator = new Validator();
                if (validator.ApiResult(content))
                {
                    List<User> res = JsonConvert.DeserializeObject<List<User>>(content);
                    BindingContext = new UserViewModels(res);
                    Debug.WriteLine(content);

                    no_data.IsVisible = false;


                    listView.IsVisible = true;
                }
                else
                {


                    no_data.IsVisible = true;


                    listView.IsVisible = false;

                }
            }
            catch (Exception e)
            {

                }
       /*     }
            else
            {
                // write your code if there is no Internet available  
                no_data.IsVisible = true;
                listview.IsVisible = false;

                var empty_label = this.FindByName<Label>("empty_label");
                empty_label.Text = "No Internet";


            }*/


        }

        //  var Items = JsonConvert.DeserializeObject<List<ItemClass>>(content);
        //  ListView1.ItemsSource = Items;





    }
 
}