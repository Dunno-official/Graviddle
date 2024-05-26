using System;
using Level.Character.CharacterMovement;
using Level.Character.CharacterMovement.CharacterInputNM;
using Level.Character.CharacterStateMachine;
using Level.Character.CharacterStateMachine.StateTransitions;
using Level.Character.Effects;
using Level.Character.Effects.SquashStretchAnimation;
using Level.Character.Effects.TwistingAnimation;
using Level.Character.Helpers;
using Level.Character.Physics;
using Level.Gravitation;
using Level.Gravitation.SwipeHandler;
using Level.Portals.FinishPortal;
using MonoBehaviourWrapper;
using UnityEngine;
using Utils.Physics;

namespace Level.Character
{
    public class Character : MonoBehaviourWrapper.MonoBehaviourWrapper
    {
        [SerializeField] private TwistingAnimationData _twistingAnimationData;
        [SerializeField] private ConstantForce2D _constantForce2d;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private ParticleSystem _fallingDust;
        [SerializeField] private CollisionsList _collisions;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public event Action Respawned;
    
        public void Initialize(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states, SwipeHandler swipeHandler, CharacterGravityState characterGravityState, CharacterInput input)
        {
            Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);
            Gravity gravity = new(_constantForce2d, 15, GravityDirection.Down);
            GravityRotation gravityRotation = new(characterGravityState, transform);
        
            SetDependencies(new IUnityCallback[]
            {
                gravity,
                gravityRotation,
                characterGravityState,
                new CharacterGravity(gravity, swipeHandler),
                new CharacterSpriteFlipping(_spriteRenderer, input),
                new CharacterRotationImpulse(_rigidbody2D, swipeHandler),
                new CharacterStateMachine.CharacterStateMachine(transitionsPresenter, states.IdleState),
                new SwipeHandlerSwitcher(swipeHandler, fallToIdleTransition, states.FallState),
                new CharacterToPortalPulling(states.WinState, transform, _collisions, gravityRotation),
                new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState),
                new TwistingAnimationHandler(_spriteRenderer, states.WinState, _twistingAnimationData, InvokeRespawnEvent),
                new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, states.FallState),
            });
        }

        private void InvokeRespawnEvent()
        {
            Respawned?.Invoke();
        }
    }
}