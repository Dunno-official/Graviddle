using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.Components
{
    public class LaserAudio : IEnable, IDisable
    {
        private readonly HitEvent.HitEvent _hitEvent;
        private readonly AudioSource _launchSound;
        private readonly AudioSource _hitSound;

        public LaserAudio(AudioSource launchSound, AudioSource hitSound, HitEvent.HitEvent hitEvent)
        {
            _launchSound = launchSound;
            _hitSound = hitSound;
            _hitEvent = hitEvent;
        }

        public void Enable()
        {
            _hitEvent.Hit += PlayHitSound;

            if (_launchSound != null)
            {
                _launchSound.Play();
            }
        }

        public void Disable()
        {
            _hitEvent.Hit -= PlayHitSound;

            if (_launchSound != null)
            {
                _launchSound.Stop();
            }
        }

        private void PlayHitSound()
        {
            if (_hitSound != null)
            {
                _hitSound.Play();
            }
        }   
    }
}