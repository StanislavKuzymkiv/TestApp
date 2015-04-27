using SQLite.Net.Attributes;
namespace TestApp.Model
{
    using Xamarin.Forms;

    using XLabs.Ioc;
    using XLabs.Platform.Device;
    using XLabs.Platform.Services.IO;

    [Table("Photos")]
	public class Photo
	{
		public Photo ()
		{
		}

		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		public string ImagePath { get; set; }
		public string Comment {get;set;}
        [Ignore]
        public ImageSource imageSource
        {
            get
            {
                var device = Resolver.Resolve<IDevice>();
                var fileStream = device.FileManager.OpenFile(ImagePath, FileMode.Open, FileAccess.Read);
                return  ImageSource.FromStream(() => fileStream);
            }
            set
            {
                
            }
        }
	}
}

