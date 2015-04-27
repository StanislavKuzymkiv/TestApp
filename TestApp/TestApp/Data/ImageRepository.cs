using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace TestApp.Data
{
    using TestApp.Model;

    public class ImageRepository
    {
        SQLiteConnection database;
        public ImageRepository(string filename)
        {
            database = DependencyService.Get<ISQLite>().GetConnection(filename);
            database.CreateTable<Photo>();
        }

        public IEnumerable<Photo> GetItems()
        {
            return (from i in database.Table<Photo>() select i).ToList();
        }
        public Photo GetItem(int id)
        {
            return database.Table<Photo>().FirstOrDefault(x => x.Id == id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Photo>(id);
        }
        public int SaveItem(Photo item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

    }
}

