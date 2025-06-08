using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace CodingTracker
{
    class Database
    {
        
        
        internal void GetDateTime()
        {
           
        }
        internal void CreateDatabase()
        {
            string dbPath = "Test.db";
            string connectionString = $"Data Source={dbPath};Version = 3;";

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableSql = @"CREATE TABLE IF NOT EXISTS CodingTracker (
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                          Name TEXT NOT NULL);";
                using (var command = new SQLiteCommand(createTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

    }
}
