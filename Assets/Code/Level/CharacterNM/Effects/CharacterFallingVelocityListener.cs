using Level.CharacterNM.CharacterStateMachine.States;
using Level.CharacterNM.CharacterStateMachine.StateTransitions;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.CharacterNM.Effects
{
    public abstract class CharacterFallingVelocityListener : CharacterFallingEventsHandler, IFixedUpdate 
    {
        private readonly Rigidbody2D _rigidbody2D;
        private float _velocity;

        protected CharacterFallingVelocityListener(Rigidbody2D rigidbody2D, Transition fallToIdleTransition, FallState fallState) : base(fallToIdleTransition, fallState)
        {
            _rigidbody2D = rigidbody2D;
        }

        void IFixedUpdate.FixedUpdate()
        {
            if (IsFalling)
            {
                _velocity = _rigidbody2D.velocity.magnitude;
                OnFalling(_velocity);
            }
        }

        protected override void OnEndFalling()
        {
            OnFell(_velocity);
        }

        protected virtual void OnFalling(float velocity) {}
        protected virtual void OnFell(float accumulatedVelocity) {}
    }
}