using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Utils.Pool;
using _2D_Laser_system.Code.Laser.Utils.Pool.Factory;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Manager
{
    public class HitEffectsPool
    {
        private readonly Dictionary<ParticleSystem, ObjectPool<PoolableParticleSystem>> _pool = new();

        public ParticleSystem GetHitEffect(ParticleSystem prefab)
        {
            if (_pool.ContainsKey(prefab) == false)
            {
                PoolableParticleSystemFactory factory = new(prefab);
                _pool[prefab] = new ObjectPool<PoolableParticleSystem>(factory);
            }

            return _pool[prefab].Create().Value;
        }

        public void Update()
        {
            foreach (ObjectPool<PoolableParticleSystem> laserPool in _pool.Values)
            {
                laserPool.Update();
            }
        }
    }
}