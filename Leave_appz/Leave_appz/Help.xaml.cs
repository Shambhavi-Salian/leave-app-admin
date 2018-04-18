using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz
{
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
            var browser = new WebView();
            browser.HorizontalOptions = LayoutOptions.FillAndExpand;
            browser.VerticalOptions = LayoutOptions.FillAndExpand;

            var source = new HtmlWebViewSource();
            var text = @"<html>" +
                "<head><link href='https://fonts.googleapis.com/css?family=Montserrat'   rel='stylesheet'></head>" +
                "<body background='https://zymolytic-brass.000webhostapp.com/assets/background.png' bgcolor=\"#FB8D00\"  style=\"text-align: justify;color:white;font-family: 'Montserrat';\"><div style=''>" +
                "<div style='font-size: 25px;'><br/<br/> <br/><b>App Name</b></div>" +

                "<br/><div style='font-size: 20px;'>This app is to request for leave on certain date admin will bla bla bla for leave on certain date admin will bla bla bla date admin will bla bla blawill bla bla bla for leave on certain date admin will bla bla bla date admin will bla bla bla will bla bla bla for leave on certain date admin will bla bla bla date admin will bla bla bla will bla bla bla for </div>" +
                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/><br/><br/>" +
                "<div style='font-size: 25px;'><b>Contact Us</b></div>" +
                "<br/><div style='font-size: 20px;'>Mobile No : +91 9989989989</div>" +
                "<div style='font-size: 20px;'>Email Id : seema.rao@prueba.io</div>"
                + "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
