using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using System.IO;
using TestApp;
using TestApp.Services;
using XLabs.Platform.Device;
using XLabs.Platform.Services.IO;


[assembly: Xamarin.Forms.Dependency(typeof(TestApp.WinPhone.PictureManager))]
namespace TestApp.WinPhone
{

    public class PictureManager : IPictureManager
    {
        public PictureManager()
		{
		}

        public void DeletePicture(string  path)
        {
            
            File.Delete(path);		
		}

        public Stream GetPictureStream(string path)
        {
            var fileStream = WindowsPhoneDevice.CurrentDevice.FileManager.OpenFile(path, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
    }

}

