using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.ConditionalUpdate;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.LifeCycleUtils
{
    public class IsPlayingCondition : IUpdateCondition
    {
        public bool IsTrue() => Application.isPlaying;
    }
}