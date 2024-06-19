using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Utils.Pool.Factory
{
    public class PoolableParticleSystemFactory : IFactory<PoolableParticleSystem>
    {
        private readonly ComponentFactory<ParticleSystem> _componentFactory;

        public PoolableParticleSystemFactory(ParticleSystem prefab)
        {
            _componentFactory = new ComponentFactory<ParticleSystem>(prefab);
        }

        public PoolableParticleSystem Create()
        {
            ParticleSystem particleSystem = _componentFactory.Create();

            return new PoolableParticleSystem(particleSystem);
        }
    }
}