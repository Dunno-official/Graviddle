using Level.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AppStartup
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private BackgroundMusicSpawner _backgroundMusicSpawner;
        [SerializeField] private UI _ui;
        private static bool _appWasInited;
    
        private async void Start()
        {
            TryInitializeGame();

            await _ui.Initialize();
        }

        private void TryInitializeGame()
        {
            if (_appWasInited == false)
            {
                _appWasInited = true;
                Application.targetFrameRate = 90;
                Addressables.InitializeAsync();
                _backgroundMusicSpawner.Initialize();
                new MusicVolume().Initialize();
            }
        }
    }
}
