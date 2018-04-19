using Xamarin.Forms;
using Leave_appz.Views;

namespace Leave_appz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Leave_appzPage();
            //SET PRIMARY TOOLBAR COLOR
            Current.Resources = new ResourceDictionary();
            Color xamarin_color = Color.DarkOrange;
            var navigationStyle = new Style(typeof(NavigationPage));
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = xamarin_color };
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            Current.Resources.Add(navigationStyle);
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
