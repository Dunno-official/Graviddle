
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;
using _2D_Laser_system.Code.Laser.Utils.FullRectLine;

namespace _2D_Laser_system.Code.Laser.Laser.Components
{
    public class LineRebuilding : IUpdate
    {
        private readonly ILaserKeyPointProvider _keyPointProvider;
        private readonly FullRectLine _fullRectLine;

        public LineRebuilding(FullRectLine fullRectLine, ILaserKeyPointProvider keyPointProvider)
        {
            _keyPointProvider = keyPointProvider;
            _fullRectLine = fullRectLine;
        }

        public void Update()
        {
            _fullRectLine.ClearPoints();

            for (int i = 0; i < _keyPointProvider.Count; ++i)
            {
                _fullRectLine.AddPoint(_keyPointProvider[i]);
            }
        
            _fullRectLine.Regenerate();
        }
    }
}