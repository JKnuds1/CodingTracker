using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Data.SqlClient;
using Dapper;


namespace CodingTracker
{
    class Database
    {

    internal DateTime StringToDate(string userInput, out DateTime timeInput)
        {
            bool success = DateTime.TryParseExact(userInput.Trim(), "HH:mm dd.MM.yyyy", CultureInfo.GetCultureInfo("nb-NO"), DateTimeStyles.None, out timeInput);
 
            if(!success)
            {
                timeInput = default;
            }
            return timeInput;

        }

    internal DateTime GetDateTime(string message)
            {
            DateTime timeInput;
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            DateTime time = StringToDate(userInput, out timeInput);
            if (time == default)
            {
                Console.WriteLine("Wrong format! Try again.");
                return GetDateTime(message);
            }
            return time;
            }

    internal CodingSession GetCodeSession()
        {
            DateTime startTime = GetDateTime("Enter the start time of the session in the format: \"HH:mm dd.MM.yyyy\".");
            DateTime endTime = GetDateTime("Enter the ending time of the session in the format: \"HH:mm dd.MM.yyyy\".");
            TimeSpan duration = endTime - startTime;
            CodingSession codingSession = new CodingSession
            {
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration
            };
            return codingSession;
        }

        internal void SessionToTable()
        {
            CodingSession session = GetCodeSession();
            using (var connection = new SQLiteConnection(Program.connectionString))
            {
                connection.Open();
                var insertQuery = "INSERT INTO CodingTracker (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
                connection.Execute(insertQuery, session);
            }
        }

    internal void PrintCodingSession(CodingSession session)
        {
            Console.WriteLine($"You started at {session.StartTime}, ended at {session.EndTime} and this lasted {session.Duration}.");
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
