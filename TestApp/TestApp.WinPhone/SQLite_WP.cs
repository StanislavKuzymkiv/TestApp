using System;
using System.Runtime.CompilerServices;
using System.IO;
using TestApp.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_WP))]

namespace TestApp.WinPhone
{
    using Windows.Storage;

    using TestApp.Data;

    public class SQLite_WP: ISQLite
	{
        public SQLite_WP()
		{
		}


		public SQLite.Net.SQLiteConnection GetConnection (string filename)
		{
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            var plat = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);
			return conn;
		}

	
	}
}

