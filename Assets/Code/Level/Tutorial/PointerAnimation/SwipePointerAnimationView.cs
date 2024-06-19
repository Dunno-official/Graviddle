using UnityEngine;

namespace Level.Tutorial.PointerAnimation
{
    public class SwipePointerAnimationView : MonoBehaviour
    {
        [SerializeField] private PointerAnimationData _data;

        private void Awake()
        {
            new PointerAnimation(_data).Play();
        }
    }
}