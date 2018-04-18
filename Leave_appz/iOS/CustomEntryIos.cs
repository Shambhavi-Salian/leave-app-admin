using System;
using Leave_appz;
using Leave_appz.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry),typeof(CustomEntryIos))]
namespace Leave_appz.iOS
{
    public class CustomEntryIos : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null){
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
               

            }
        }
    }
}
