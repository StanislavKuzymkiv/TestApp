using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;
using System.IO;

namespace TestApp.Droid
{
    using TestApp.Services;

    [Activity (Label = "TestProject.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			SetupIoc ();

			LoadApplication (new App ());

		}
		private void SetupIoc (){
			var container = new SimpleContainer ();
			container.Register<IDevice> (t => AndroidDevice.CurrentDevice);
			container.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			container.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			container.Register<IPictureManager> (new PictureManager());
			Resolver.SetResolver (container.GetResolver ());
		}
	}

}

