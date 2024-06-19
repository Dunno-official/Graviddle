using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace Level.AnalyticsNM
{
    public class LevelRecordPostRequest
    {
        private readonly string _serverUrl = "http://localhost:5225/";

        public async void Execute(LevelRecord record)
        {
            string requestUrl = _serverUrl + "post/" + JsonConvert.SerializeObject(record);
            UnityWebRequest postAnalyticsRequest = UnityWebRequest.Get(requestUrl);

            await postAnalyticsRequest.SendWebRequest().ToUniTask();
        }
    }
}