namespace SaveSystem
{
    public interface ISaveLoadSystem
    {
        void Save<T>(string key, T data);
        bool HasKey(string key);
        T Load<T>(string key);
    }
}