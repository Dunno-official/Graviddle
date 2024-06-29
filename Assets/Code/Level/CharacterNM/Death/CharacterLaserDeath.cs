using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using UnityEngine;

namespace Level.CharacterNM
{
    public class CharacterLaserDeath : MonoBehaviour, ILaserEntered, IDeathCondition
    {
        private bool _isDead;

        private bool UpdateIsDead()
        {
            bool state = _isDead;

            _isDead = false;

            return state;
        }

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _isDead = true;
        }

        public bool IsDead(out string reason)
        {
            reason = "Died from laser";
            return UpdateIsDead();
        }
    }
}