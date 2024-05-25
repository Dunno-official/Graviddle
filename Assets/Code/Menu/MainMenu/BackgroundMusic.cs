using UnityEngine;

namespace Menu.MainMenu
{
    public class BackgroundMusic : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}