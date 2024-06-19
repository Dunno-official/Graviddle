using UnityEngine;

namespace _2D_Laser_system.Demo.Game.UFO
{
    public class UFODeath
    {
        private readonly Transform _transform;
        private readonly Vector2 _startPosition;
    
        public UFODeath(Transform transform)
        {
            _transform = transform;
            _startPosition = transform.position;
        }
    
        public void Restart()
        {
            _transform.position = _startPosition;
        }
    }
}