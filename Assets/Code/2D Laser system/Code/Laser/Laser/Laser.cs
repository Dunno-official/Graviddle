using System;
using _2D_Laser_system.Code.Laser.Laser.Components.HitEvent;
using _2D_Laser_system.Code.Laser.Laser.LaserLifeCycleFactory;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser
{
    public class Laser : LaserBase 
    {
        private LaserComponents _components;
        
        public Guid Id { get; private set; } = Guid.NewGuid();
        public RaycastHitEvent HitEvent => _components.HitEvent;

        protected override ILaserLifeCycleFactory CreateLifeCycleFactory()
        {
            _components = new LaserComponents(Data, Dissolve, this);
            Data.Line.Initialize(GetComponent<MeshFilter>());
            
            return new LaserLifeCycleFactory.LaserLifeCycleFactory(Switcher, Dissolve, _components);
        }

        public void BranchLaser(Laser parent)
        {
            TryInitialize();
            Id = parent.Id;
            _components.HitEvent.InheritEvents(parent._components.HitEvent);
        }

        public void Enable(Transform laserPoint)
        {
            if (Switcher.Enabled == false)
            {
                Enable();
                _components.TransformMapper.SetSource(laserPoint);
            }
        }
    }
}