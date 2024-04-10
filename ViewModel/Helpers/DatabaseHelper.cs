using SQLite;
using System.IO;

namespace OrderManager.ViewModel.Helpers
{
    class DatabaseHelper
    {

        private static string databaseName = "Orders.db3";
        private static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string dbFile = Path.Combine(folderPath, databaseName);
        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                int rowsCount = connection.Insert(item); // vrací int, počet sloupců
                if (rowsCount > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int rowsCount = conn.Update(item);// vrací int, počet sloupců
                if (rowsCount > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                int rowsCount = connection.Delete(item);// vrací int, počet sloupců
                if (rowsCount > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }

            return items;
        }
    }
}
