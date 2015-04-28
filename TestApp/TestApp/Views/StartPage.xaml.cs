using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using Xamarin.Forms;
using TestApp.Services;

namespace TestApp.Views
{
    public partial class StartPage : ContentPage
    {
        private IMediaPicker _mediaPicker;
        private CameraManager _manager;
        private MediaFile file;

        public StartPage()
        {
            var service = new DependencyServiceManager();
            _mediaPicker = service.MediaPicker;
            InitializeComponent();
        }
        private async void TakePicture(object sender, EventArgs e)
        {
            _manager = new CameraManager(_mediaPicker);
            file = await _manager.TakePhotoFromCamera();
			if (file != null) {
				await Navigation.PushAsync (new ConfirmPage (file));
			}
        }
        private void ShowPhotoList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GalleryPage());
        }
    }
}

