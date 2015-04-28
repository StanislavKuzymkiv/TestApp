using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using XLabs.Platform.Services.Media;

namespace TestApp.Services
{
    public class CameraManager
    {
        private IMediaPicker _mediaPicker;

        public CameraManager(IMediaPicker picker)
        {
            _mediaPicker = picker;
        }
        public async Task<MediaFile> TakePhotoFromCamera()
        {
            try
            {
                return await
                    _mediaPicker.TakePhotoAsync(
                        new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(
                            t =>
                                {
                                    var mediaFile = t.Result;
                                    return mediaFile;
                                });
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
