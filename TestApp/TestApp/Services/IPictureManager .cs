using Xamarin.Forms;
namespace TestApp.Services
{
    using System.IO;

    public interface IPictureManager 
	{
        void DeletePicture(string imagePath);

        Stream GetPictureStream(string path);

	}
}

