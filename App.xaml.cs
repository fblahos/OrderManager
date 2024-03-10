using System.IO;
using System.Windows;

namespace OrderManager
{
    public partial class App : Application
    {
        public static string databaseName = "AL_Orders.db";
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = Path.Combine(folderPath, databaseName);
    }
}
