using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class LeaveInfo : ContentPage
    {
        public LeaveInfo()
        {
            InitializeComponent();
            var browser = new WebView();
            browser.HorizontalOptions = LayoutOptions.FillAndExpand;
            browser.VerticalOptions = LayoutOptions.FillAndExpand;

            var source = new HtmlWebViewSource();
            var text = @"<html>" +
                "<head><link href='https://fonts.googleapis.com/css?family=Montserrat'   rel='stylesheet'></head>" +
                "<body background='https://zymolytic-brass.000webhostapp.com/assets/background.png' bgcolor=\"#FB8D00\"  style=\"text-align: justify;color:white;font-family: 'Montserrat';\"><div style=''>" +
                "<div style='font-size: 25px;'><br/<br/> <br/><b>Sick Leave</b></div>" +

                "<br/><div style='font-size: 20px;'>Sick leave can be take 1 per day Everythying about sick leav here And try to fill this Text Box. about sick leave here And try to fill this Text Box.  </div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/>" +
                "<div style='font-size: 25px;'> <br/><b>Casual Leave</b></div>" +
                "<br/><div style='font-size: 20px;'> Sick leave can be take 1 per day Everythying about sick leav here And try to fill this Text Box. about sick leave here And try to fill this Text Box.  </div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/>" +
                "<div style='font-size: 25px;'> <br/><b>Earned Leave</b></div>" +
                "<br/><div style='font-size: 20px;'>Sick leave can be take 1 per day Everythying about sick leav here And try to fill this Text Box. about sick leave here And try to fill this Text Box.  </div>" +
                 "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
