using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButtonClamping : IUpdate
    {
        private readonly GravityButtonData _data;
        private readonly Transform _button;

        public GravityButtonClamping(GravityButtonData data, Transform button)
        {
            _button = button;
            _data = data;
        }

        public void Update()
        {
            Vector2 clampedPosition = _button.transform.localPosition;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0, _data.TopExtremePoint);
            _button.transform.localPosition = clampedPosition;
        }
    }
}
