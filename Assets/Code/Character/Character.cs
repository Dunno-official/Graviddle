﻿using System.Collections.Generic;
using System.Linq;
using Character.CharacterStateMachine;
using Character.CharacterStateMachine.StateTransitions;
using Character.Physics;
using Extensions;
using Level.Gravitation.SwipeHandler;
using Level.Restart;
using Level.UnityCallbackWrappers;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour, IRestart, IAfterRestart
    {
        [SerializeField] private SwipeHandler _swipeHandler;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ParticleSystem _fallingDust;
        [SerializeField] private TrailRenderer _trailRenderer;
        private IEnumerable<IAfterRestart> _afterRestartComponents;
        private IEnumerable<IRestart> _restartComponents;
        private IEnumerable<ISubscriber> _subscribers;
        private IEnumerable<IUpdatable> _updatables;


        public void Init(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states)
        {
            Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);
        
            object[] dependencies = 
            {
                new CharacterStateMachine.CharacterStateMachine(transitionsPresenter, states.IdleState),
                new CharacterPhysicsRestart(_rigidbody2D),
                new CharacterTransparency.CharacterTransparency(_spriteRenderer, states.WinState),
                new CharacterRotationImpulse(_rigidbody2D, _swipeHandler),
                new SwipeHandlerSwitcher(_swipeHandler, fallToIdleTransition, states.FallState),
                new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState)
            };

            dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Init());
            _afterRestartComponents = dependencies.OfType<IAfterRestart>();
            _restartComponents = dependencies.OfType<IRestart>();
            _subscribers = dependencies.OfType<ISubscriber>();
            _updatables = dependencies.OfType<IUpdatable>();
        }


        private void OnEnable()
        {
            _subscribers.SubscribeForEach();
        }


        private void OnDisable()
        {
            _subscribers.UnsubscribeForEach();
        }


        private void Update()
        {
            _updatables.UpdateForEach();
        }
    

        void IRestart.Restart()
        {
            _restartComponents.RestartForEach();
        }
    
    
        void IAfterRestart.Restart()
        {
            _afterRestartComponents.RestartForEach();
        }
    }
}