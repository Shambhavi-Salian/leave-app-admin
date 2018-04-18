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
    public partial class FirstView : ContentPage
    {
        public FirstView()
        {
            InitializeComponent();
            var nav = new NavigationPage(new ContentPage { Title = "Page" });
            nav.BarBackgroundColor = Color.LightYellow;

        }
    }
}