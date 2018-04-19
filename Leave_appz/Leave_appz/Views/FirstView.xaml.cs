
﻿using Leave_appz.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Leave_appz.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstView : ContentPage
    {
        WebView browser;
        EmployeeVM employeeVM;
        public FirstView()
        {
            InitializeComponent();
            employeeVM = new EmployeeVM();
            BindingContext = employeeVM;
            browser = leaveDetailsWV;
            browser.HorizontalOptions = LayoutOptions.FillAndExpand;
            browser.VerticalOptions = LayoutOptions.FillAndExpand;
            try
            {
                var source = new HtmlWebViewSource();

                var text = @"<html>" +
                    "<head><link href='https://fonts.googleapis.com/css?family=Montserrat'   rel='stylesheet'></head>" +
                    "<body background='https://zymolytic-brass.000webhostapp.com/assets/background.png' bgcolor=\"#FB8D00\"  style=\"text-align: justify;color:white;font-family: 'Montserrat';\">" +
                        "<div>Ohh!!! There are no contents. Please select the user.</div>" +
                        "</body>" +
                        "</html>";
                source.Html = text;
                browser.Source = source;
            }
            catch (Exception e)
            {

            }

            // OnAppearing();
            //AddContentToPicker();
            //  GetAllUserList();
            //var nav = new NavigationPage(new ContentPage { Title = "Page" });
            //nav.BarBackgroundColor = Color.LightYellow;
            //SetPicker();

        }

        async override protected void OnAppearing()
        {
            base.OnAppearing();
            NetworkModel.NetworkManager networkManager = new NetworkModel.NetworkManager();
            if (networkManager.IsNetworkAvailable())
            {
                try
                {
                    var json = await GetEmployeesList();
                    System.Diagnostics.Debug.WriteLine("Employees content json:" + json);
                    List<EmployeeVM> employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(json);
                    System.Diagnostics.Debug.WriteLine("Employees content employees" + employees.Count);
                    foreach (EmployeeVM em in employees)
                    {
                        System.Diagnostics.Debug.WriteLine("Employees content ID:" + em.email_id);
                        if (em.email_id != null)
                        {
                            // int id = em.Data.id;
                            string ID = em.email_id;
                            System.Diagnostics.Debug.WriteLine("Employees content:" + ID);

                            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                            // employeeViewModel.id = id;
                            employeeViewModel.email_id = ID;
                            EmployeeList.Items.Add(ID);
                            employeeVM.EmployeeList.Add(employeeViewModel);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                await DisplayAlert("Warning", "No network, please check your internet connection and try again", "Ok");
            }
        }

        async Task<string> GetEmployeesList()
        {
            try
            {
                var client = new HttpClient();
                var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=5";

                client.BaseAddress = new Uri(RestURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(RestURL);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else return response.ReasonPhrase;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        async void GetLeaveDetails(string userName)
        {

            try
            {
                NetworkModel.NetworkManager networkManager = new NetworkModel.NetworkManager();
                if (networkManager.IsNetworkAvailable())
                {
                    var client = new HttpClient();
                    var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=13&useremail=" + userName;
                    //var formContent = new FormUrlEncodedContent(new[]
                    // {
                    //   new KeyValuePair<string, string>("id", "13"),
                    //   new KeyValuePair<string, string>("useremail", userName), });


                    client.BaseAddress = new Uri(RestURL);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(RestURL);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine("success code:" + result);
                        System.Diagnostics.Debug.WriteLine(result);
                        int index = result.IndexOf("<img", 0);
                        if (index != -1)
                        {

                            var source = new HtmlWebViewSource();
                            System.Diagnostics.Debug.WriteLine(result.Substring(0, index));
                            var text = result.Substring(0, index);
                            source.Html = text;
                            browser.Source = source;
                        }
                        else
                        {
                            var source = new HtmlWebViewSource();

                            var text = result;
                            source.Html = text;
                            browser.Source = source;
                        }

                    }
                }
                else
                {
                    await DisplayAlert("Warning", "No network, please check your internet connection and try again", "Ok");
                }
            }
            catch (Exception e)
            {

            }
        }

        async void GetLeaveCounts(string userName, string typeOfLeave)
        {
            NetworkModel.NetworkManager networkManager = new NetworkModel.NetworkManager();
            if (networkManager.IsNetworkAvailable())
            {
                try
                {
                    var client = new HttpClient();
                    var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=6&useremail=" + userName + "&type_of_leave=" + typeOfLeave;
                    System.Diagnostics.Debug.WriteLine("RestUrl:" + RestURL);
                    client.BaseAddress = new Uri(RestURL);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(RestURL);
                    var json = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var leaveModel = JsonConvert.DeserializeObject<UserDataModel.UserLeaveCount>(json);
                        if (typeOfLeave.Equals("0"))
                        {
                            sick.Text = "+" + leaveModel.leave_count;
                        }
                        else if (typeOfLeave.Equals("1"))
                        {
                            casual.Text = "+" + leaveModel.leave_count;
                        }
                        else
                        {
                            earned.Text = "+" + leaveModel.leave_count;
                        }
                    }
                    catch (JsonSerializationException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        await DisplayAlert("Warning", "Unable to fetch leave details", "OK");
                    }
                }
                catch (Exception e)
                {

                }
                }
            else
            {
                await DisplayAlert("Warning", "No network, please check your internet connection and try again", "Ok");
            }
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object selectedItem;
                if (EmployeeList.SelectedIndex != -1)
                {
                    selectedItem = EmployeeList.SelectedItem;
                    System.Diagnostics.Debug.WriteLine("selected item:" + selectedItem);
                    GetLeaveDetails(selectedItem.ToString());
                    GetLeaveCounts(selectedItem.ToString(), "0");
                    GetLeaveCounts(selectedItem.ToString(), "1");
                    GetLeaveCounts(selectedItem.ToString(), "2");
                }
            }catch(Exception e1)
            {

            }
           // var picker = (Picker)sender;
           // object selectedItem = picker.SelectedItem;
           
            // if (selectedIndex != -1)
            // {
            //   listLabel.Text = picker.Items[selectedIndex];
            // }
        }

        private async void GetAllUserList()
        {
            try
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
                // picker.ItemsSource = list;
                //picker.Title = "Shambhavi";

                //picker.TextColor = white;

                var listLabel = new Label();
            }
            catch (Exception e)
            {

            }
            //   listLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
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
           
            //picker.ItemsSource = list;
            //picker.SelectedIndex = 0;
            //picker.Title = "Shambhavi";
            
            //picker.TextColor = white;

            var listLabel = new Label();
            //listLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
        }
     
    }

    public class RootObject
    {
        public string email_id { get; set; }
    }
}
