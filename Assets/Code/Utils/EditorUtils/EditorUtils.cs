using UnityEngine;

namespace Utils.EditorUtils
{
    public static class EditorUtils 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeMethodLoad()
        {
#if UNITY_EDITOR

            Level.UI.UI ui = Object.FindObjectOfType<Level.UI.UI>();
        
            if (ui != null)
            {
                //ui.Show<GameplayPanel>();
            }

#endif  
        }
    }
}
