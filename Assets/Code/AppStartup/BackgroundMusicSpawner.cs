using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class BackgroundMusicSpawner
{
    [SerializeField] private BackgroundMusic _backgroundMusic;

    public void Initialize()
    {
        Object.Instantiate(_backgroundMusic);
    }
}