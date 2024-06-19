﻿
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;

namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle
{
    public class LifeCycle
    {
        private readonly IDisable _disableAction;
        private readonly IEnable _enableAction;
        private readonly IUpdate _updateCycle;
        
        public LifeCycle(IEnable enableAction, IDisable disableAction, IUpdate updateCycle)
        {
            _disableAction = disableAction;
            _enableAction = enableAction;
            _updateCycle = updateCycle;
        }

        public void Enable()
        {
            _enableAction.Enable();
        }

        public void Disable()
        {
            _disableAction.Disable();
        }

        public void Update()
        {
            _updateCycle.Update();
        }
    }
}