using Level.CharacterNM.CharacterStateMachineNM.States;
using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
using UnityEngine;

namespace Level.CharacterNM.Effects
{
    public class CharacterVFX : CharacterFallingVelocityListener
    {
        private readonly ParticleSystem _fallingDust;
        private readonly TrailRenderer _trailRenderer;
        private readonly float _dustVelocityThreshold = 10;

        public CharacterVFX(ParticleSystem fallingDust, TrailRenderer trailRenderer, Transition fallToIdleTransition,
            FallState fallState, Rigidbody2D rigidbody2D)
            : base(rigidbody2D, fallToIdleTransition, fallState)
        {
            _trailRenderer = trailRenderer;
            _fallingDust = fallingDust;
        }

        protected override void OnStartFalling()
        {
            _trailRenderer.emitting = true;
        }

        protected override void OnFell(float accumulatedVelocity)
        {
            _trailRenderer.emitting = false;

            if (accumulatedVelocity > _dustVelocityThreshold)
            {
                _fallingDust.Play();
            }
        }
    }
}