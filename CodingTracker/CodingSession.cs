﻿using System;

namespace CodingTracker
{
    public class CodingSession
    {
        public int Id { get; set; }
        
        public DateTime StartTime { get; set;}

        public DateTime EndTime { get; set;}

        public string Duration { get; set; }
    }
}
