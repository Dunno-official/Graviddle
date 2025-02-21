using Extensions;
using Level.CharacterNM;
using Level.Gravitation;
using Level.Obstacles.LaserTurretNM;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Obstacles
{
    public class LaserTurret : MonoBehaviour
    {
        [SerializeField] private Transform _turret;
        [SerializeField] private Transform _turretAnchor;
        [SerializeField] private Transform _fastening;
        [SerializeField] private CharacterHead _target;
        private IUpdate[] _updatables;

        public void Initialize(IGravityState characterGravityState)
        {
            TurretRotationData turretRotationData = new(_target, _turret, 1.5f);
            TurretRotationData fasteningRotationData = new(_target, _fastening, 2f);
        
            _updatables = new IUpdate[]
            {
                new TurretPosition(_turret, _turretAnchor),
                new TurretRotation(turretRotationData),
                new TurretFasteningRotation(fasteningRotationData, characterGravityState, transform)
            };
        }

        private void Update()
        {
            _updatables.UpdateForEach();
        }
    }
}
