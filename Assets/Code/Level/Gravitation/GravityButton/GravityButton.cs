using System;
using Level.LightBulbNM;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    public class GravityButton : MonoBehaviour, ISwitcher
    {
        [SerializeField] private AudioSource _toggleSound;
        private const float _downExtremePoint = 0.06f;
        private const float _topExtremePoint = 0.35f;
        private bool _isButtonTurnedOn;

        public event Action<bool> Toggled;
    
        private void Update()
        {
            TryInvokePressEvent(transform.localPosition.y > _topExtremePoint, false);
            TryInvokePressEvent(transform.localPosition.y < _downExtremePoint, true);
        }

        private void TryInvokePressEvent(bool condition, bool isTurnedOn)
        {
            if (condition && _isButtonTurnedOn != isTurnedOn)
            {
                _isButtonTurnedOn = isTurnedOn;
                _toggleSound.Play();
                Toggled?.Invoke(isTurnedOn);
            }
        }
    }
}