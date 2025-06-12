using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using Spectre.Console;


namespace CodingTracker
{
    class Database
    {
        internal static void InsertSession(CodingSession session)
        {
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                var insertQuery = "INSERT INTO CodingTracker (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
                connection.Execute(insertQuery, session);
            }
        }
        internal static void ViewTable()
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Duration");
            table.AddColumn("Start Time");
            table.AddColumn("End Time");
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                var insertQuery = "SELECT * FROM CodingTracker";
                List<CodingSession> sessions = connection.Query<CodingSession>(insertQuery).ToList();

                foreach (var session in sessions)
                {
                    table.AddRow($"{session.Id}",$"{session.Duration}",$"{session.StartTime}",$"{session.EndTime}");
                }
            }
            AnsiConsole.Write(table);
        }
        internal static void DeleteSession()
        {
            ViewTable();
            int id = UserInput.GetId("Insert the Id number of the session you want to delete.\nEnter 0 to get to the Main menu.");
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                var deleteQuery = "DELETE FROM CodingTracker WHERE Id = @Id";
                connection.Execute(deleteQuery, new { Id = id });
            }
        }

        internal static void UpdateSession()
        {
            ViewTable();
            int updateId = UserInput.GetId("Insert the Id number of the session you want to update.\nEnter 0 to get to the Main menu.");
            CodingSession updateSession = UserInput.GetCodeSession();
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                
                var updateQuery = "UPDATE CodingTracker SET StartTime= @starttime, EndTime=@endtime,Duration=@duration WHERE Id = @id";
                connection.Execute(updateQuery, new {id = updateId,
                                                     starttime=updateSession.StartTime,
                                                     endtime=updateSession.EndTime,
                                                     duration = updateSession.Duration});
            }
        }

        internal void CreateDatabase(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            //string connectionString = $"data source={dbPath};version = 3;";
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                string createTableSql = @"CREATE TABLE IF NOT EXISTS CodingTracker (
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                          StartTime TEXT,
                                          EndTime TEXT,
                                          Duration TEXT);";
                using (var command = new SQLiteCommand(createTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }


            }
        }

    }
}
