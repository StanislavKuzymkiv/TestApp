using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.IO;
using TestApp.Core;

[assembly: Xamarin.Forms.Dependency(typeof(TestApp.Droid.PictureManager))]
namespace TestApp.Droid
{
    public class PictureManager : IPictureManager
    {        
        public PictureManager()
		{
           
		}

        public void DeletePicture(string path)
        {

            File.Delete(GetImagePath(path));
        }

        public string GetImagePath(string path)
        {
            var imageName = Path.GetFileName(path);

            return imageName;
        }
    }
}

