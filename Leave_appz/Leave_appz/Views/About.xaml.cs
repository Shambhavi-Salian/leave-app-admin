using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Leave_appz.Views
{
    public partial class About : ContentPage
    {
        public About()
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
                "<br/><div style='font-size: 20px;'>Version 1.19.16.7.8</div>" +
                "<div style='font-size: 20px;'>Release Beata</div>" +
                "<div style='font-size: 20px;'>Copyright (c) Lt Designing 1010,</div>" +
                "<div style='font-size: 20px;'>2050. All rights reserved</div>" +

                "<br/><div style='background-color:white;height:1px;border: 0px;'></div><br/><br/><br/>" +
                "<div style='font-size: 25px;'><b>Thanks To</b></div>" +
                "<br/><div style='font-size: 20px;'>User Name - App designer</div>" +
                "<div style='font-size: 20px;'>User Name- Database Designer </div>" +
                "<div style='font-size: 20px;'>User Name- Database Designer </div>" +
                "<div style='font-size: 20px;'>User Name- Database Designer </div>" +
                "<div style='font-size: 20px;'>User Name- Database Designer </div>" +
                "<div style='font-size: 20px;'>User Name- Database Designer </div>" +
                "<br/><div style='font-size: 20px;'>Made with Love In prueba</div>"
                + "<br/><div style='background-color:white;height:1px;border: 0px;'></div> </div>" +
                    "</body>" +
                    "</html>";
            source.Html = text;
            browser.Source = source;
            webViewLayout.Children.Add(browser);
        }
    }
}
