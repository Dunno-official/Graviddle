using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AppStartup
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private BackgroundMusicSpawner _backgroundMusicSpawner;
        private readonly MusicVolume _musicVolume = new MusicVolume();
        private static bool _appWasInited;
    
    
        private void Start()
        {
            if (_appWasInited == false)
            {
                _appWasInited = true;
                Initialize();
            }
        }


        private void Initialize()
        {
            Addressables.InitializeAsync();
            _backgroundMusicSpawner.Init();
            _musicVolume.Init();
        }
    }
}
