using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.IO;
using TestApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(TestApp.iOS.PictureManager))]
namespace TestApp.iOS
{
    public class PictureManager : IPictureManager
    {
        public PictureManager()
		{
           
		}

        public void DeletePicture(string path)
        {

            File.Delete(path);
        }
        public Stream GetPictureStream(string path)
        {
            var fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

    }
}

