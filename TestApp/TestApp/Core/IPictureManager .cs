using Xamarin.Forms;
namespace TestApp.Core
{

    public interface IPictureManager 
	{
        void DeletePicture(string imagePath);

       string  GetImagePath(string imagePath);
	}
}

