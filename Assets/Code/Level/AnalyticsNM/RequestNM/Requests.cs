namespace Level.AnalyticsNM.RequestNM
{
    public static class Requests
    {
        public static PostRequest LevelRecord => new(BaseUrl + "postLevelRecord");
        public static PostRequest DeathRecord => new(BaseUrl + "postDeathRecord");
        private static string BaseUrl => "http://localhost:5225/";
    }
}