using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace DeeplinkingSample.Droid
{
    [Activity(Label = "DeeplinkingSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   
    [IntentFilter(new[] {Android.Content.Intent.ActionView },
       DataScheme = "testAppForLinks",
       Categories = new[] {
        Android.Content.Intent.ActionView,
        Android.Content.Intent.CategoryDefault,
        Android.Content.Intent.CategoryBrowsable
    })]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AndroidAppLinks.Init(this);
            LoadApplication(new App());

            if (Intent != null && Intent.DataString != null)
            {
                try
                {
                    string email = "";
                    email = Intent.Data.GetQueryParameter("email");

                    if (email != null && email != "")
                    {
                        //write something here
                    }
                }
                catch (Exception e)
                {
                    //Catch error
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}