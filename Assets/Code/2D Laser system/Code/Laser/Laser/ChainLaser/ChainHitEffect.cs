using _2D_Laser_system.Code.Laser.Laser.Components;
using _2D_Laser_system.Code.Laser.Laser.Components.HitEffect;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.ChainLaser
{
    public class ChainHitEffect : HitEffect
    {
        public ChainHitEffect(ParticleSystem effectPrefab, LaserActiveHits activeHits, ILaserKeyPointProvider keyPointProvider) : base(effectPrefab, activeHits, keyPointProvider)
        {
        }

        protected override int GetEffectHits(int activeHits) => activeHits;
    }
}