using System;
using System.IO;
using System.Data.SQLite;
namespace CodingTracker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Database db = new Database();
            db.CreateDatabase();
        }
    }
}
