using System;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;

namespace _2D_Laser_system.Code.Laser.Laser.Components.HitEvent
{
    public class HitEvent : IUpdate
    {
        private readonly LaserActiveHits _activeHits;
        private int _currentHits;
        public event Action Hit;
        
        public HitEvent(LaserActiveHits activeHits)
        {
            _activeHits = activeHits;
        }

        void IUpdate.Update()
        {
            if (_currentHits != _activeHits.Value)
            {
                _currentHits = _activeHits.Value;

                if (_currentHits != 0)
                {
                    Hit?.Invoke();
                    OnHit(_currentHits);
                }
            }
        }

        protected virtual void OnHit(int hitIndex) {}
    }
}