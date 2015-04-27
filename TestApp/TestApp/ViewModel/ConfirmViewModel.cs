using System.Threading.Tasks;
using TestApp.Core;
using TestApp.View;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Platform.Services.Media;

namespace TestApp.ViewModel
{
    [ViewType(typeof(ConfirmPage))]
    public class ConfirmViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private ImageSource _image;
        private IMediaPicker _mediaPicker;
        private IPictureManager _pictureManager;
        private CameraManager _manager;

        private MediaFile _media;

        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                SetProperty(ref _image, value);
            }
        }
        public Command TakePictureCommand
        {
            get
            {
                return new Command(async () => await TakePicture(), () => true);
            }
        }

        public ConfirmViewModel(MediaFile file)
        {
            _media = file;
            var service = new DependencyServiceManager();
            _mediaPicker = service.MediaPicker;
            _pictureManager = service.PictureManager;
            _image = ImageSource.FromStream(() => file.Source);
        }

        private async Task TakePicture()
        {
            _pictureManager.DeletePicture(_media.Path);
            Image = null;
            _manager = new CameraManager(_mediaPicker);
            var file = await _manager.TakePhotoFromCamera();
            ConfirmPage._mediFile = file;
            Image = ImageSource.FromStream(() => file.Source);

        }


    }
}


