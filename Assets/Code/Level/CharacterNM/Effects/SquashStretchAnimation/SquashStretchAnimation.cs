using Level.CharacterNM.CharacterStateMachineNM.States;
using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
using UnityEngine;

namespace Level.CharacterNM.Effects.SquashStretchAnimation
{
    public class SquashStretchAnimation : CharacterFallingVelocityListener 
    {
        private readonly Stretch _stretch;
        private readonly Squash _squash;

        public SquashStretchAnimation(Rigidbody2D rigidbody, SpriteRenderer sprite, Transition fallToIdleTransition, FallState fallState) 
            : base(rigidbody, fallToIdleTransition, fallState)
        {
            _stretch = new Stretch(sprite.transform);
            _squash = new Squash(sprite.transform);
        }

        protected override void OnFalling(float velocity)
        {
            _stretch.SetStretch(velocity);
        }

        protected override void OnFell(float accumulatedVelocity)
        {
            _squash.Play(accumulatedVelocity);
        }
    }
}