using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    class UserInput
    {
        internal static CodingSession GetCodeSession()
        {
            DateTime startTime = GetDateTime("Enter the start time of the session in the format: \"HH:mm dd.MM.yyyy\" or enter \"Now\" to get the current time.");
            DateTime endTime = GetDateTime("Enter the ending time of the session in the format: \"HH:mm dd.MM.yyyy\" or enter \"Now\" to get the current time.");
            string duration = (endTime - startTime).ToString();
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
            if (success)
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
                var now = DateTime.Now;
                DateTime truncatedNow = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                return truncatedNow;
            }

            else if (time == default)
            {
                Console.WriteLine("Wrong format! Try again.");
                return GetDateTime(message);
            }
            return time;
        }
    }
}
