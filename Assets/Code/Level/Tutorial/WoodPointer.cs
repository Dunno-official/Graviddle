using Coffee.UIEffects;
using UnityEngine;

namespace Level.Tutorial
{
    public class WoodPointer : MonoBehaviour
    {
        [SerializeField] private UIDissolve _dissolveImage;

        public float Duration => _dissolveImage.effectPlayer.duration;
    
        public void ShowHint()
        {
            _dissolveImage.Play();
        }

        public void ResetImage()
        {
            _dissolveImage.Stop();
        }
    }
}