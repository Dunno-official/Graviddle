using Level.UnityCallbackWrappers;
using UnityEngine;

namespace Obstacles.LaserTurretNM
{
    public class TurretPosition : IUpdatable
    {
        private Transform _turret;
        private Transform _anchor;

        public TurretPosition(Transform turret, Transform anchor)
        {
            _turret = turret;
            _anchor = anchor;
        }


        void IUpdatable.Update()
        {
            _turret.position = _anchor.position;
        }
    }
}