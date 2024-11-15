using Level.CameraNM.Clamping;
using UnityEngine;
using Utils;

namespace Level.CameraNM
{
    public class CharacterCapture : TogglingComponent
    {
        private readonly CameraClamping _cameraClamping;
        private readonly Transform _transform;
        private readonly Rigidbody2D _target;
        private Vector3 _velocity;

        public CharacterCapture(Rigidbody2D rigidbody, Transform transform, CameraBordersWithOrientation borders)
        {
            _cameraClamping = new CameraClamping(borders);
            _transform = transform;
            _target = rigidbody;
        }

        protected override void OnFixedUpdate()
        {
            float captureTime = EvaluateCaptureTimeFunction(_target.linearVelocity.magnitude);
            Vector3 clampedPosition = _cameraClamping.Clamp(_target.transform.position);

            _transform.position = Vector3.SmoothDamp(_transform.position, clampedPosition, ref _velocity, captureTime);
        }

        private float EvaluateCaptureTimeFunction(float x)
        {
            return 1 / (0.15f * x  + 3.33f);
        }
    }
}