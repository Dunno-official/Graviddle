using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Utils.Pool
{
    public class PoolableParticleSystem : IPoolable
    {
        public readonly ParticleSystem Value;
        public bool IsActive => Value.isPlaying;

        public PoolableParticleSystem(ParticleSystem value)
        {
            Value = value;
        }
    
        public void Reset()
        {
            Value.gameObject.SetActive(true);
        }

        public void ReturnToPool()
        {
            Value.gameObject.SetActive(false);
        }
    }
}