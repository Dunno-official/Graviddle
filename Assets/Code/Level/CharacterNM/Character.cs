using System;
using Level.CharacterNM.CharacterMovement;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachine;
using Level.CharacterNM.CharacterStateMachine.StateTransitions;
using Level.CharacterNM.Effects;
using Level.CharacterNM.Effects.SquashStretchAnimation;
using Level.CharacterNM.Effects.TwistingAnimation;
using Level.CharacterNM.Helpers;
using Level.CharacterNM.Physics;
using Level.Gravitation;
using Level.Gravitation.SwipeHandlerNM;
using Level.Portals;
using MonoBehaviourWrapperNM;
using UnityEngine;
using Utils.Physics;
using Utils.Physics.Cast;

namespace Level.CharacterNM
{
    public class Character : MonoBehaviourWrapper
    {
        [SerializeField] private TwistingAnimationData _twistingAnimationData;
        [SerializeField] private ConstantForce2D _constantForce2d;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CircleCastData _circleCastData;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private ParticleSystem _fallingDust;
        [SerializeField] private CollisionsList _collisions;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Animator _animator;

        public CharacterStatesPresenter States { get; private set; }
        public event Action Respawned;

        public void Initialize(TransitionsConditions conditions, SwipeHandler swipeHandler, CharacterGravityState characterGravityState, CharacterInput input)
        {
            States = new CharacterStatesPresenter(_animator, input, _circleCastData);
            Gravity gravity = new(_constantForce2d, 15, GravityDirection.Down);
            GravityRotation gravityRotation = new(characterGravityState, transform);
            TransitionsPresenterFactory transitionsPresenterFactory = new(States, conditions);
            TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
            Transition fallToIdleTransition = transitionsPresenter.GetTransition(States.FallState, States.IdleState);

            SetDependencies(new IUnityCallback[]
            {
                gravity,
                gravityRotation,
                characterGravityState,
                new CharacterGravity(gravity, swipeHandler),
                new CharacterSpriteFlipping(_spriteRenderer, input),
                new CharacterRotationImpulse(_rigidbody2D, swipeHandler),
                new CharacterStateMachine.CharacterStateMachine(transitionsPresenter, States.IdleState),
                new SwipeHandlerSwitch(swipeHandler, fallToIdleTransition, States.FallState),
                new CharacterToPortalPulling(States.WinState, transform, _collisions, gravityRotation),
                new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, States.FallState, _rigidbody2D),
                new TwistingAnimationHandler(_spriteRenderer, States.WinState, _twistingAnimationData, InvokeRespawnEvent),
                new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, States.FallState),
            });
        }

        private void InvokeRespawnEvent()
        {
            Respawned?.Invoke();
        }
    }
}