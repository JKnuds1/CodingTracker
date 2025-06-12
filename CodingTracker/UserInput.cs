using System;
using System.Globalization;

namespace CodingTracker
{
    class UserInput
    {
        internal static CodingSession GetCodeSession()
        {
            DateTime startTime = GetDateTime("Enter the start time of the session in the format: \"HH:mm dd.MM.yyyy\" or enter \"Now\" to get the current time. \nEnter 0 to get to the Main menu.");
            DateTime endTime = GetDateTime("Enter the ending time of the session in the format: \"HH:mm dd.MM.yyyy\" or enter \"Now\" to get the current time.\nEnter 0 to get to the Main menu.");
            string duration = GetDuration(startTime,endTime);
            CodingSession codingSession = new CodingSession
            {
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration
            };
            return codingSession;
        }
        internal static int GetId(string message)
        {
            int id;
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            bool success = int.TryParse(userInput, out id);
            if (userInput == "0")
            {
                Menu.GetMainMenu();
            }
            else if (success)
            {
                return id;
            }
            Console.WriteLine("Input is not an integer. Try again.");
            return GetId(message);
        }
        internal static DateTime StringToDate(string userInput, out DateTime timeInput)
        {
            bool success = DateTime.TryParseExact(userInput.Trim(), "HH:mm dd.MM.yyyy", CultureInfo.GetCultureInfo("nb-NO"), DateTimeStyles.None, out timeInput);

            if (!success)
            {
                timeInput = default;
            }
            return timeInput;

        }
        internal static DateTime GetDateTime(string message)
        {
            DateTime timeInput;
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            DateTime time = StringToDate(userInput, out timeInput);
            if (userInput.ToLower() == "now")
            {
                return GetTimeNow();
            }
            else if (userInput == "0")
            {
                Menu.GetMainMenu();
            }
            else if (time == default)
            {
                Console.WriteLine("Wrong format! Try again.");
                return GetDateTime(message);
            }
            return time;
        }
        internal static DateTime GetTimeNow()
        {
            var now = DateTime.Now;
            DateTime truncatedNow = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            return truncatedNow;
        }
        internal static string GetDuration(DateTime start, DateTime end)
        {
            TimeSpan duration = end - start;
            TimeSpan truncatedDuration = new TimeSpan(duration.Days,duration.Hours,duration.Minutes,duration.Seconds);
            return truncatedDuration.ToString();
        }
    }
}
