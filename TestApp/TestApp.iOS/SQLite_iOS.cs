using System;
using System.Runtime.CompilerServices;
using System.IO;
using TestApp.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_iOS))]

namespace TestApp.iOS
{
    using TestApp.Data;

    public class SQLite_iOS: ISQLite
	{
		public SQLite_iOS ()
		{
		}


		public SQLite.Net.SQLiteConnection GetConnection (string filename)
		{
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string gallerypath = Path.Combine(documentsPath, "..", "Gallery");
			var path = Path.Combine(documentsPath, filename);
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);
			return conn;
		}

	
	}
}

