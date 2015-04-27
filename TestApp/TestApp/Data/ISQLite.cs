using SQLite.Net;

namespace TestApp.Data
{
    public interface ISQLite
	{
		SQLiteConnection GetConnection(string filename);
	}
}

