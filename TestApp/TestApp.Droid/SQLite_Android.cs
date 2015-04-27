using System;
using System.Runtime.CompilerServices;
using System.IO;
using TestApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]

namespace TestApp.Droid
{
    using TestApp.Data;

    public class SQLite_Android: ISQLite
	{
		public SQLite_Android ()
		{
		}


		public SQLite.Net.SQLiteConnection GetConnection (string filename)
		{
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, filename);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);
			return conn;
		}

	
	}
}

