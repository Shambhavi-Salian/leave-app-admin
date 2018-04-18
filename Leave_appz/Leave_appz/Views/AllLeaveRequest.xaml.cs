
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Leave_appz.ViewModels;
using Leave_appz.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace Leave_appz.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllLeaveRequest : ContentPage
	{
		public AllLeaveRequest()
		{
            
            InitializeComponent();
           // BindingContext = new UserViewModels();


           LoadData();

        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
           /* if (CrossConnectivity.Current.IsConnected)
            {***/
                try
                {

                    var content = "";
                    var admin_action = "";
                    Button button = (Button)sender;
                    StackLayout stackLayout = (StackLayout)button.Parent;
                    StackLayout stackLayout1 = (StackLayout)stackLayout.Parent;
                    Label label = (Label)stackLayout1.Children[0];
                    Validator validator = new Validator();
                    if (validator.checkActionPerformed(button.Text))
                    {
                        admin_action = "1";
                    }
                    else if (!validator.checkActionPerformed(button.Text))
                    {
                        admin_action = "2";

                    }

                    HttpClient client = new HttpClient();
                    // var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=4&date=2018-02-01"; 
                    var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=9&auto_id=" + label.Text + "& status=" + admin_action;
                    Debug.WriteLine(RestURL);
                    client.BaseAddress = new Uri(RestURL);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(RestURL);
                    content = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(content);
                    if (validator.LeavePersmissionResult(content))
                    {


                        await DisplayAlert(button.Text + "ed Leave Request!",
              null, "OK");


                        var emailTask = Plugin.Messaging.CrossMessaging.Current.EmailMessenger;

                        Label mail_label = (Label)stackLayout1.Children[1];
                        if (emailTask.CanSendEmail)
                        {
                            // Send simple e-mail to single receiver without attachments, CC, or BCC.

                            //   emailTask.SendEmail("plugins@xamarin.com", "Xamarin Messaging Plugin", "Hello from your friends at Xamarin!");

                            // Send a more complex email with the EmailMessageBuilder fluent interface.
                            //string email_adress = ((Button)sender).Tag;


                            var email = new Plugin.Messaging.EmailMessageBuilder()
                                 .To(mail_label.Text)

                                 .Subject("Reply-Leave Request")
                                 .Body("Your leave request " + button.Text + "ed")
                                 .Build();

                            emailTask.SendEmail(email);
                        }



                        LoadData();


                    }
                    else
                    {
                        await DisplayAlert("Failed", "Please try again", "OK");
                    }

                }
                catch (Exception e)
                {

                }
          /*  }
            else
            {

                await DisplayAlert("No Internet", "Please try again", "OK");

            }*/
            }


        async void LoadData()
        {
          /*  if (CrossConnectivity.Current.IsConnected)
            {*/
                // your logic...  
           
            try { 
            var content = "";
            HttpClient client = new HttpClient();
            // var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=4&date=2018-02-01"; 
            var RestURL = "http://zymolytic-brass.000webhostapp.com/?id=2";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var progress_parent = this.FindByName<AbsoluteLayout>("progress_parent");
            progress_parent.IsVisible = false;
            var leaveListView = this.FindByName<ListView>("leaveListView");
            var no_data = this.FindByName<AbsoluteLayout>("no_data");
            Validator validator = new Validator();
            if (validator.ApiResult(content))
            {
              
                List<User> res = JsonConvert.DeserializeObject<List<User>>(content);
                BindingContext = new UserViewModels(res);
                Debug.WriteLine(content);
                no_data.IsVisible = false;
                leaveListView.IsVisible = true;

            }

            else
            {
              

                no_data.IsVisible = true;
                leaveListView.IsVisible = false;

            }
            }
            catch (Exception e)
            {

            }
            try
            {
                leaveListView.EndRefresh();
            }
            catch (Exception e)
            {
              
            }

     /*       }
            else
            {
                // write your code if there is no Internet available  
                no_data.IsVisible = true;
                leaveListView.IsVisible = false;

                var empty_label = this.FindByName<Label>("empty_label");
                empty_label.Text = "No Internet";


            }*/


        }

        protected void ListItems_Refreshing(object sender, EventArgs e)
        {
            LoadData(); //my method for repopulating the list  
            //this is a very important step. It will refresh forever without triggering it   }

        }
        }


}