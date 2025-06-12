using System.Configuration;
namespace CodingTracker
{
    class Program
    {
        public static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        public static string dbPath = ConfigurationManager.AppSettings.Get("dbPath");
        public static bool running = true;
        static void Main(string[] args)
        {
            Database db = new Database();
            db.CreateDatabase(dbPath);
            
            Menu.GetMainMenu();
        }
    }
}
