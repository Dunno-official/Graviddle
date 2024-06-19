﻿using _2D_Laser_system.Code.Laser.Laser.Components.Dissolve;
using _2D_Laser_system.Code.Laser.Laser.Data;
using _2D_Laser_system.Code.Laser.Laser.LaserLifeCycleFactory;
using _2D_Laser_system.Code.Laser.Utils;
using _2D_Laser_system.Code.Laser.Utils.Pool;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public abstract class LaserBase : PoolableMonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LaserData _data;
        private LifeCycle.LifeCycle _lifeCycle;

        protected readonly Switcher Switcher = new();
        protected LaserDissolve Dissolve { get; private set; }
        public override bool IsActive => Dissolve.IsAnimating || Switcher.Enabled;
        public LaserData Data => _data;

        private void Start()
        {
            TryInitialize();
        }

        protected void TryInitialize()
        {
            if (_lifeCycle == null && _data != null)
            {
                Dissolve = new LaserDissolve(_data.ViewData);
                _lifeCycle = CreateLifeCycleFactory().Create();
                _data.Line.Initialize(GetComponent<MeshFilter>());
            }
        }
    
        private void OnDisable()
        {
            Disable();
        }
    
        public void Enable()
        {
            TryInitialize();
            
            if (Switcher.TryEnable())
            {
                _lifeCycle.Enable();
            }
        }

        public void Disable()
        {
            TryInitialize();
            
            if (Switcher.TryDisable())
            {
                _lifeCycle.Disable();
            }
        }

        private void Update()
        {
            _lifeCycle.Update();
        }

        protected abstract ILaserLifeCycleFactory CreateLifeCycleFactory();
    }
}