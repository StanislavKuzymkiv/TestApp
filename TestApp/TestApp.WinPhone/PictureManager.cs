using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using System.IO;
using TestApp;

[assembly: Xamarin.Forms.Dependency(typeof(TestApp.WinPhone.PictureManager))]
namespace TestApp.WinPhone
{
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    using TestApp.Core;

    using XLabs.Forms.Controls;

    using ImageSourceConverter = System.Windows.Media.ImageSourceConverter;
    using Path = System.IO.Path;

    public class PictureManager : IPictureManager
    {
        public PictureManager()
		{
		}

        public void DeletePicture(string  path)
        {
            
            File.Delete(GetImagePath(path));		
		}

        public string GetImagePath(string path)
        {
            var imageName = Path.GetFileName(path);
            //var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), imageName);
            
            return imageName;
        }
    }

}

