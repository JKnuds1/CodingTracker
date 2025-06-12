using System;
namespace CodingTracker
{
    class StopWatch
    {
        private static DateTime startTime;
        private static TimeSpan timespent;
        private static bool runWatch;
        private static void start()
        {
            startTime = DateTime.Now;
        }
        private static void tick()
        {
            timespent = DateTime.Now - startTime;
        }
        internal static void Timer()
        {
            runWatch = true;
            start();
            while (runWatch)
            {
                tick();
                Console.Clear();
                Console.WriteLine(timespent);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if(key.Key == ConsoleKey.Enter)
                    {
                        runWatch = false;
                        Console.ReadLine();
                        break;
                    }
                }
            }
            DateTime endTime = UserInput.GetTimeNow();
            string duration = UserInput.GetDuration(startTime,endTime);
            CodingSession timerSession = new CodingSession{StartTime = startTime, EndTime=endTime,Duration = duration}; 
            Database.InsertSession(timerSession);
              
            
        }
    }
}
