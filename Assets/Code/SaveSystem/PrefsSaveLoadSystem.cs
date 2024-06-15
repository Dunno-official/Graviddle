using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class PrefsSaveLoadSystem : ISaveLoadSystem
    {
        public void Save<T>(string key, T data)
        {
            PlayerPrefs.SetString(key, JsonConvert.SerializeObject(data));
        }

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public T Load<T>(string key)
        {
            string json = PlayerPrefs.GetString(key);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}