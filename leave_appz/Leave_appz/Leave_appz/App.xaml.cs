using System.Collections.ObjectModel;
using Xamarin.Forms;
using Leave_appz.Views;

namespace Leave_appz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

         //   var nav = new NavigationPage
           // {
            //    Title = "Detail",
               
                
            //};
           /// nav.PushAsync(new MainNavigationPage() { Title = "Home" });
//nav.BarBackgroundColor = Color.OrangeRed;

          //  var mdp = new MainNavigationPage()
           // {
               
              //  Detail = nav,
              
           // };
           // MainPage = mdp;
           MainPage = new MainNavigationPage();
 
            //Background color
            //MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);

            //Title color
            // MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);

            //var navigationPage = Application.Current.MainPage as NavigationPage;
            // navigationPage.BarBackgroundColor = Color.Black;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
