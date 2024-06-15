using UnityEngine;

namespace Utils.EditorUtils
{
    public class DebugStop : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Break();
            }
        }
    }
}