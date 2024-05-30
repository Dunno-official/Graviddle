using System;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButtonEvents : IUpdate
    {
        private GravityButtonData _data;
        private Transform _button;
        private bool _state;

        public void Initialize(GravityButtonData data, Transform button)
        {
            _button = button;
            _data = data;
        }

        public event Action<bool> Toggled;
        public event Action Enabled;
        public event Action Disabled;
        
        void IUpdate.Update()
        {
            TryInvokePressEvent(_button.localPosition.y > _data.TopExtremePoint, false);
            TryInvokePressEvent(_button.localPosition.y < _data.BottomExtremePoint, true);
        }

        private void TryInvokePressEvent(bool condition, bool state)
        {
            if (condition && _state != state)
            {
                _state = state;
                Toggled?.Invoke(state);

                if (_state)
                {
                    Enabled?.Invoke();
                }
                else
                {
                    Disabled?.Invoke();
                }
            }
        }
    }
}