using Level.CameraNM.Clamping.Data;
using Level.CharacterNM.Helpers;
using Level.Gravitation;
using MonoBehaviourWrapperNM;

namespace Level.CameraNM.Clamping
{
    public class CameraBordersWithOrientation : ISubscriber
    {
        private readonly CameraClampingSettings _cameraClampingSettings;
        private readonly IGravityState _gravityState;
        private float _orientationOffset;

        public CameraBordersWithOrientation(CameraClampingSettings clampingSettings, IGravityState gravityState)
        {
            _cameraClampingSettings = clampingSettings;
            _gravityState = gravityState;
        }

        public float Top => _cameraClampingSettings.CameraBorders.Top - _orientationOffset;
        public float Down => _cameraClampingSettings.CameraBorders.Down + _orientationOffset;
        public float Left => _cameraClampingSettings.CameraBorders.Left - _orientationOffset;
        public float Right => _cameraClampingSettings.CameraBorders.Right + _orientationOffset;

        void ISubscriber.Subscribe()
        {
            _gravityState.DirectionChanged += OnGravityChanged;
        }

        void ISubscriber.Unsubscribe()
        {
            _gravityState.DirectionChanged -= OnGravityChanged;
        }

        private void OnGravityChanged()
        {
            bool isHorizontalOrientation = _gravityState.Direction == GravityDirection.Down || 
                                           _gravityState.Direction == GravityDirection.Up;

            _orientationOffset = isHorizontalOrientation ? 0 : _cameraClampingSettings.OrientationOffset;
        }
    }
}