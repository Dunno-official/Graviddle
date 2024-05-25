using UnityEngine;

public class MusicVolume
{
    private const string _musicVolume = "MusicVolume";

    public void Initialize()
    {
        float volume;
        
        if (PlayerPrefs.HasKey(_musicVolume))
        {
            volume = PlayerPrefs.GetFloat(_musicVolume);
        }

        else
        {
            volume = 1;
            PlayerPrefs.SetFloat(_musicVolume, volume);
        }
        
        AudioListener.volume = volume; 
    }
}