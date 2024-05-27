using UnityEngine;

namespace Utils.EditorUtils
{
    public static class EditorUtils 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeMethodLoad()
        {
#if UNITY_EDITOR

            Level.UserInterface.UI ui = Object.FindObjectOfType<Level.UserInterface.UI>();
        
            if (ui != null)
            {
                //ui.Show<GameplayPanel>();
            }

#endif  
        }
    }
}
