using SQLite.Net.Attributes;
using System.IO;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.IO;


namespace TestApp.Models
{
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
				return Device.OnPlatform (
					ImageSource.FromFile (ImagePath),
					ImageSource.FromFile (ImagePath),             
					ImageSource.FromStream (() => Resolver.Resolve<IDevice> ().FileManager.OpenFile (ImagePath, FileMode.Open, FileAccess.Read)));
            }
            set
            {
                
            }
        }
	}
}

