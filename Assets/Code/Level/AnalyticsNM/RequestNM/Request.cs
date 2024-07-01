using System.Text;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace Level.AnalyticsNM.RequestNM
{
    public abstract class Request
    {
        private readonly string _method;
        private readonly string _url;

        protected Request(string url, string method)
        {
            _method = method;
            _url = url;
        }

        public UniTask Send(object body = null)
        {
            UnityWebRequest request = new();
            request.url = _url;
            request.method = _method;
            request.downloadHandler = new DownloadHandlerBuffer();
            request.uploadHandler = new UploadHandlerRaw(GetBody(body));
            request.SetRequestHeader("Accept", "application/json");
            request.SetRequestHeader("Content-Type", "application/json");
            request.timeout = 60;
            
            return request.SendWebRequest().ToUniTask();
        }

        private byte[] GetBody(object body)
        {
            string bodyString = null;
            
            if (body is string result)
            {
                bodyString = result;
            }
            
            else if (body != null)
            {
                bodyString = JsonConvert.SerializeObject(body);
            }

            return EncodeBody(bodyString);
        }

        private byte[] EncodeBody(string body)
        {
            return string.IsNullOrEmpty(body) ? null : Encoding.UTF8.GetBytes(body);
        }
    }
}