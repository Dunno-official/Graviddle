using System;

namespace Level.AnalyticsNM
{
    [Serializable]
    public class DeathRecord
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string ScreenShot { get; set; }
        public string[] Reasons { get; set; }
    }
}