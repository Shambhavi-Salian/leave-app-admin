using JsonModelClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Leave_appz
{
    public partial class Leave_appzPage : ContentPage
    {
        public Leave_appzPage()
        {
            InitializeComponent();
            backgroundImage.Source = ImageSource.FromResource("Leave_appz.Assets.background.png");
            whitelogoImage.Source = ImageSource.FromResource("Leave_appz.Assets.whitelogoss.png");
        }

        public void DisplayAlertMessage(string message)
        {
            DisplayAlert("Warning", message, "Ok");
        }

        
        void LoginProcedure(object sender, EventArgs eventArgs)
        {
            UserDataModel userDataModel = new UserDataModel(user_email.Text, user_password.Text);
            NetworkModel.NetworkManager networkManager = new NetworkModel.NetworkManager();
            if (networkManager.IsNetworkAvailable())
            {
                if (userDataModel.CheckInformation())
                {
                    var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=2";
                    //RestService restService = new RestService();
                    //restService.PostRequest(RestURL, userDataModel);
                    PostRequest(RestURL, userDataModel);

                }

                else
                {
                    DisplayAlertMessage("Username and Password text fields are empty");
                }

            }
            else
            {
                DisplayAlertMessage("No network, please check your internet connection and try again");
            }
        }


        public async void PostRequest(string URL, UserDataModel userDataModel)
        {
            NetworkModel.NetworkManager networkManager = new NetworkModel.NetworkManager();
            if(networkManager.IsNetworkAvailable())
            {
                System.Diagnostics.Debug.WriteLine("asa");
                var formContent = new FormUrlEncodedContent(new[]
                    {
               new KeyValuePair<string, string>("id", "1"),
               new KeyValuePair<string, string>("useremail", userDataModel.email_id),
               new KeyValuePair<string, string>("password", userDataModel.user_password),
           });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync(URL, formContent);

                var json = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(json);

                try
                {
                    var userModel = JsonConvert.DeserializeObject<JsonModelClass.UserDataModel>(json);
                    if (userModel.email_id.Trim().Equals(user_email.Text.Trim()) && userModel.user_password.Trim().Equals(user_password.Text.Trim()))
                    {
                        Application.Current.Properties["email"] = user_email.Text.Trim();
                        Application.Current.Properties["password"] = user_password.Text.Trim();
                        //await DisplayAlert("Warning", "login", "ok");
                        Application.Current.MainPage = new MainNavigationPage();
                        // await Navigation.PushAsync(new MainNavigationPage());
                    }
                    else
                    {
                        await DisplayAlert("Warning", "Wrong User Name Or Password", "ok");
                    }
                }
                catch (JsonSerializationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    await DisplayAlert("Warning", "Wrong User Name Or Password", "ok");
                }

            }
            else
            {
                await DisplayAlert("Warning", "No network, please check your internet connection and try again", "ok");
            }
            
    }


        public async void CompareCredentials(UserDataModel userModel)
        {
            try {
                if (userModel.email_id.Trim().Equals(user_email.Text.Trim()) && userModel.user_password.Trim().Equals(user_password.Text.Trim()))
                {
                    Application.Current.Properties["email"] = user_email.Text.Trim();
                    Application.Current.Properties["password"] = user_password.Text.Trim();
                    await DisplayAlert("warning", "Login Success", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new MainNavigationPage(), true);
                }
                else
                {
                   await DisplayAlert("warning","Wrong User Name Or Password","Ok");
                }
            }
            catch (JsonSerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                await DisplayAlert("Warning", "Wrong User Name Or Password", "ok");
            }

        }
    }
}
