using System;
using Menu.MainMenu;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AppStartup
{
    [Serializable]
    public class BackgroundMusicSpawner
    {
        [SerializeField] private BackgroundMusic _backgroundMusic;

        public void Initialize()
        {
            Object.Instantiate(_backgroundMusic);
        }
    }
}