namespace SaveSystem
{
    public class UserName
    {
        private readonly ISaveLoadSystem _saveLoadSystem = new PrefsSaveLoadSystem();
        private readonly string _key = "Name";

        public bool Exists()
        {
            return _saveLoadSystem.HasKey(_key);
        }
        
        public void Save(string name)
        {
            _saveLoadSystem.Save(_key, name);
        }

        public string Load()
        {
            return _saveLoadSystem.Load<string>(_key);
        }
    }
}