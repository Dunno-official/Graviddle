﻿using System;

namespace Level.AnalyticsNM
{
    [Serializable]
    public class LevelRecord
    {
        public string DeviceId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Stars { get; set; }
        public string Level { get; set; } = null!;
        public double Time { get; set; }
        public int DeathCount { get; set; }
    }
}