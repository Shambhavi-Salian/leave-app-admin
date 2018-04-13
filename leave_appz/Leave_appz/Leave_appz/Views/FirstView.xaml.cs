using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Leave_appz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstView : ContentPage
    {
        public FirstView()
        {
            InitializeComponent();
            //AddContentToPicker();
            GetAllUserList();
            //var nav = new NavigationPage(new ContentPage { Title = "Page" });
            //nav.BarBackgroundColor = Color.LightYellow;
            //SetPicker();

        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

           // if (selectedIndex != -1)
           // {
             //   listLabel.Text = picker.Items[selectedIndex];
           // }
        }

        private async void GetAllUserList()
        {
            HttpClient client = new HttpClient();
            var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=5";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            var content = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("content:" + content);

            var list = JsonConvert.DeserializeObject<List<RootObject>>(content);
            //var list = new List<string>();
            //list.Add("abc");
           // foreach(List listItems in list )
           // var listOfUsers = new List<RootObject>();
           // listOfUsers.Add(list.IndexOf()0;
            picker.ItemsSource = list;
            picker.SelectedIndex = 0;
            //picker.Title = "Shambhavi";

            //picker.TextColor = white;

            var listLabel = new Label();
            listLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
        }

        public void AddContentToPicker()
        {
           // string allUser = GetAllUser();
            var list = new List<string>();
            list.Add("SHAMBHAVI");
            list.Add("SHAMBHAVI");
            list.Add("SHAMBHAVI");
            list.Add("SHAMBHAVI");
            list.Add("SHAMBHAVI");
            list.Add("SHAMBHAVI");
           
            picker.ItemsSource = list;
            picker.SelectedIndex = 0;
            //picker.Title = "Shambhavi";
            
            //picker.TextColor = white;

            var listLabel = new Label();
            listLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
        }
     
    }

    public class RootObject
    {
        public string email_id { get; set; }
    }
}