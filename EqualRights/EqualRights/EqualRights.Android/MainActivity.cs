using Android.App;
using Android.Content.PM;
using Android.OS;
using EqualRights.Droid.Services;
using EqualRights.Service.Interface;
using Prism;
using Prism.Ioc;

namespace EqualRights.Droid
{
    [Activity(Label = "EqualRights", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations

            containerRegistry.Register<IDocumentViewer, DroidDocumentViewer>();
        }
    }
}

