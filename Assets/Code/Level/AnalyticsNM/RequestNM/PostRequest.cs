using UnityEngine.Networking;

namespace Level.AnalyticsNM.RequestNM
{
    public class PostRequest : Request
    {
        public PostRequest(string url) : base(url, UnityWebRequest.kHttpVerbPOST)
        {
        }
    }
}