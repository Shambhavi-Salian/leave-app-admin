using Leave_appz.Models;
using Leave_appz.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Leave_appz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavigationPage 
    {
        public List<MasterPageItem> menuList { get; set; }



        public MainNavigationPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
          

            //Fot Ios icons
            var page1 = new MasterPageItem() { Title = "Leave Of A User", TargetType = typeof(FirstView) };
            var page2 = new MasterPageItem() { Title = "All Leave Request", TargetType = typeof(AllLeaveRequest) };
            var page3 = new MasterPageItem() { Title = "Leave Per Day", TargetType = typeof(CurrentdayAbsent) };
            var page4 = new MasterPageItem() { Title = "About Developer", TargetType = typeof(Help) };
            var page5 = new MasterPageItem() { Title = "Help", TargetType = typeof(Help) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);

            // Setting our list to be ItemSource for ListView in MasterDetailPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
         //   Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ContentPage)));

          //  Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ContentPage))) { BarBackgroundColor = Color.Green };
           
            this.BindingContext = new
            {
                Header = "Leave App",
                Image = "whitelogoss.png",
         
                // Color = "#ed4715",
                //Footer = "         -------- Welcome To HotelPlaza --------           "
            };
            
            Type page = page1.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page)) { BarBackgroundColor = Color.DarkOrange };

            IsPresented = false;

            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page)) { BarBackgroundColor = Color.DarkOrange };

            IsPresented = false;
       }

        


        //  private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //    {
        //     var item = e.SelectedItem as MainNavigationPage;
        //     if (item == null)
        //        return;

        //  var page = (Page)Activator.CreateInstance(item.TargetType);
        //  page.Title = item.Title;

        // Detail = new NavigationPage(page);
        //  IsPresented = false;

        //MasterPage.ListView.SelectedItem = null;
        // }
    }
}