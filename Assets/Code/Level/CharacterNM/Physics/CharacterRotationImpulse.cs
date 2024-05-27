using Level.Gravitation;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.CharacterNM.Physics
{
    public class CharacterRotationImpulse : ISubscriber
    {
        private readonly IGravityState _gravityState;
        private readonly Rigidbody2D _rigidbody;
        private const int _straightAngle = 180;
        private int _currentZRotation;

        public CharacterRotationImpulse(Rigidbody2D rigidbody2D, IGravityState gravityState)
        {
            _rigidbody = rigidbody2D;
            _gravityState = gravityState;
        }

        void ISubscriber.Subscribe()
        {
            _gravityState.DirectionChanged += TryImpulseCharacter;
        }

        void ISubscriber.Unsubscribe()
        {
            _gravityState.DirectionChanged -= TryImpulseCharacter;
        }

        private void TryImpulseCharacter()
        {
            int newZRotation = _gravityState.Data.ZRotation;

            if (IsRightAngleRotation(newZRotation))
            {
                _rigidbody.AddForce(_rigidbody.transform.up, ForceMode2D.Impulse);
            }

            _currentZRotation = newZRotation;
        }

        private bool IsRightAngleRotation(float zRotation)
        {
            return Mathf.Abs(zRotation - _currentZRotation) % _straightAngle != 0;
        }
    }
}