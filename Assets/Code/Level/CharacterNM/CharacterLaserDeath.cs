using System.Collections.Generic;
using LaserSystem2D;
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