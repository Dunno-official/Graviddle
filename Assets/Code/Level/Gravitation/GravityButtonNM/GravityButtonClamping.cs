using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButtonNM
{
    public class GravityButtonClamping : IUpdate
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly GravityButtonData _data;
        private readonly Transform _button;

        public GravityButtonClamping(GravityButtonData data, Transform button, Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _button = button;
            _data = data;
        }

        public void Update()
        {
            Vector2 clampedPosition = _button.transform.localPosition;
            bool resetVelocity = clampedPosition.y < _data.BottomClampPoint;  
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, _data.BottomClampPoint, _data.TopExtremePoint);
            _button.transform.localPosition = clampedPosition;

            if (resetVelocity)
            {
                _rigidbody2D.linearVelocity = Vector2.zero;
            }
        }
    }
}
