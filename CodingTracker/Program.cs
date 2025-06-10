using System;
using System.Configuration;
namespace CodingTracker
{
    class Program
    {
        public static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        public static string dbPath = ConfigurationManager.AppSettings.Get("dbPath");
        static void Main(string[] args)
        {
            //Database db = new Database();
            //db.CreateDatabase(dbPath);
            //db.SessionToTable();
            Menu.GetMainMenu();

        }
    }
}
