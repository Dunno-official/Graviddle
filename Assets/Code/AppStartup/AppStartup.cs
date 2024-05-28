using Level.UserInterface;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AppStartup
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private BackgroundMusicSpawner _backgroundMusicSpawner;
        [SerializeField] private UI _ui;

        private async void Start()
        {
            TryInitializeGame();

            await _ui.Initialize();
        }

        private void TryInitializeGame()
        {
            bool isFirstTime = FindObjectsByType<AppStartup>(FindObjectsSortMode.None).Length == 1;
            
            if (isFirstTime)
            {
                Application.targetFrameRate = 90;
                Addressables.InitializeAsync();
                _backgroundMusicSpawner.Initialize();
                new MusicVolume().Initialize();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
