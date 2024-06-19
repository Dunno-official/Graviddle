
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;
using _2D_Laser_system.Code.Laser.Utils.FullRectLine;

namespace _2D_Laser_system.Code.Laser.Laser.ChainLaser
{
    public class ChainLaserMaxPointUpdate : IUpdate
    {
        private readonly ILaserKeyPointProvider _keyPointProvider;
        private readonly FullRectLine _fullRectLine;

        public ChainLaserMaxPointUpdate(ILaserKeyPointProvider keyPointProvider, FullRectLine fullRectLine)
        {
            _keyPointProvider = keyPointProvider;
            _fullRectLine = fullRectLine;
        }

        public void Update()
        {
            _fullRectLine.MaxPoints = _keyPointProvider.Count;
        }
    }
}