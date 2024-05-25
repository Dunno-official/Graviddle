using Level.UI.Switchers;
using UnityEngine;

namespace SceneTransitions
{
    public class LevelUIEnabling : MonoBehaviour
    {
        // enable UI when level was loaded
        private void OnDestroy()
        {
            var uiStatesSwitcher = FindAnyObjectByType<UIStatesSwitcher>(FindObjectsInactive.Include);
            uiStatesSwitcher.gameObject.SetActive(true);
        }
    }
}