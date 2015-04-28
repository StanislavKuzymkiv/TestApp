using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Services;
using Foundation;
using UIKit;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace TestApp.iOS
{
   
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			SetupIoc ();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
		private void SetupIoc (){
			var container = new SimpleContainer ();
			container.Register<IDevice> (t => AppleDevice.CurrentDevice);
			container.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			container.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			container.Register<IPictureManager> (new PictureManager());
			Resolver.SetResolver (container.GetResolver ());
		}
    }
}
