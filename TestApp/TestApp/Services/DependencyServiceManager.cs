using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace TestApp.Services
{
   

    public class DependencyServiceManager
    {
        public IMediaPicker MediaPicker { get; private set; }

        public IPictureManager PictureManager{ get; private set; }
        public DependencyServiceManager()
        {
             var device = Resolver.Resolve<IDevice>();
            MediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
            PictureManager = DependencyService.Get<IPictureManager>() ?? Resolver.Resolve<IPictureManager>();
        }

    }
}
