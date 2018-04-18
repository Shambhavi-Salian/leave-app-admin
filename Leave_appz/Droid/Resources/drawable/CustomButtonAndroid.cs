using System;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Leave_appz;
using Leave_appz.Droid;
using Android.Graphics.Drawables;
[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonAndroid))]
namespace Leave_appz.Droid
{
    public class CustomButtonAndroid:ButtonRenderer
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.SetBackgroundResource(Resource.Layout.rounded_shape);

            }
        }
    }
}
