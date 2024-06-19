using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using UnityEngine;

namespace Level.CharacterNM
{
    public class CharacterLaserDeath : MonoBehaviour, ILaserEntered
    {
        private bool _isDead;

        public bool GetState()
        {
            bool state = _isDead;

            _isDead = false;

            return state;
        }

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _isDead = true;
        }
    }
}