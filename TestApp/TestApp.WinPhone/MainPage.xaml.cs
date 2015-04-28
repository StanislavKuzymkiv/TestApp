using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using TestApp.Services;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;

namespace TestApp.WinPhone
{

    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            SetupIoc();
            LoadApplication(new TestApp.App());
        }
        private void SetupIoc()
        {
            var container = new SimpleContainer();
            container.Register<IDevice>(t => WindowsPhoneDevice.CurrentDevice);
            container.Register<IMediaPicker>(t => t.Resolve<IMediaPicker>());
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
            container.Register<IPictureManager>(new PictureManager());
            Resolver.SetResolver(container.GetResolver());
        }

    }
}
