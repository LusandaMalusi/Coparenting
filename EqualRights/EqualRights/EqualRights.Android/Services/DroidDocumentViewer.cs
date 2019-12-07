using Android.Content;
using Android.OS;
using Android.Support.V4.Content;
using EqualRights.Service.Interface;
using Java.IO;

namespace EqualRights.Droid.Services
{
    public class DroidDocumentViewer : IDocumentViewer
    {

        public DroidDocumentViewer()
        {
        }

        public void ViewDocument(string path, string documentName)
        {
            var localPath = System.IO.Path.Combine(path, documentName);

            var file = new File(localPath);
            var intent = new Intent(Intent.ActionView);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
            {
                var apkUri = FileProvider.GetUriForFile(Android.App.Application.Context,
                    "com.companyname.appname.fileprovider", file);
                intent.SetDataAndType(apkUri, "application/pdf");
                intent.SetFlags(ActivityFlags.NoHistory);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            }
            else
            {
                intent.SetDataAndType(Android.Net.Uri.FromFile(file), "application/pdf");
                intent.SetFlags(ActivityFlags.NoHistory);
            }

            Xamarin.Forms.Forms.Context.StartActivity(intent);
        }
    }
}
