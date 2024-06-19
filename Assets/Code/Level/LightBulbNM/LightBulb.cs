using Level.Gravitation.GravityButtonNM;
using UnityEngine;

namespace Level.LightBulbNM
{
    public class LightBulb : MonoBehaviour
    {
        [SerializeField] private GravityButton _gravityButton;
        [SerializeField] private Animator _animator;
        private readonly string _switchingOnAnimationName = "SwitchingOn";
        private readonly string _switchingOffAnimationName = "SwitchingOff";

        private void OnEnable()
        {
            _gravityButton.Events.Disabled += DisableLightBulb;
            _gravityButton.Events.Enabled += EnableLightBulb;
        }

        private void OnDisable()
        {
            _gravityButton.Events.Disabled -= DisableLightBulb;
            _gravityButton.Events.Enabled -= EnableLightBulb;
        }

        private void EnableLightBulb()
        {
            _animator.Play(_switchingOnAnimationName);
        }

        private void DisableLightBulb()
        {
            _animator.Play(_switchingOffAnimationName);
        }
    }
}