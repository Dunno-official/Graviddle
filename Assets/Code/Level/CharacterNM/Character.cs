using System;
using Level.CameraNM;
using Level.CharacterNM.CharacterMovement;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachineNM;
using Level.CharacterNM.CharacterStateMachineNM.StateTransitions;
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
        [SerializeField] private CurveAnimationData _rotationData;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CircleCastData _circleCastData;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private ParticleSystem _fallingDust;
        [SerializeField] private CollisionsList _collisions;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Animator _animator;
        
        public CharacterStatesPresenter States { get; private set; }
        public event Action Respawned;

        public void Initialize(TransitionsConditions conditions, CharacterGravityState gravityState, CharacterInput input, SwipeHandler swipeHandler)
        {
            States = new CharacterStatesPresenter(_animator, input, _circleCastData);
            Gravity gravity = new(_constantForce2d, 15, GravityDirection.Down);
            SingleGravityRotation gravityRotation = new(transform, _rotationData, gravityState, this);
            TransitionsPresenterFactory transitionsPresenterFactory = new(States, conditions);
            TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
            Transition fallToIdleTransition = transitionsPresenter.GetTransition(States.FallState, States.IdleState);

            SetDependencies(new IUnityCallback[]
            {
                gravity,
                gravityRotation,
                gravityState,
                new CharacterGravity(gravity, gravityState),
                new CharacterSpriteFlipping(_spriteRenderer, input),
                new CharacterRotationImpulse(_rigidbody2D, gravityState),
                new CharacterStateMachine(transitionsPresenter, States.IdleState),
                new SwipeHandlerSwitch(swipeHandler, fallToIdleTransition, States.FallState),
                new CharacterToPortalPulling(States.WinState, transform, _collisions),
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