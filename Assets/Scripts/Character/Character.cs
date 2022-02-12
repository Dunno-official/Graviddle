﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Character : MonoBehaviour, IRestartableTransform, IRestart, IAfterRestart
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


    public void Init(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states, CharacterRestartEvent restartEvent)
    {
        Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);
        
        object[] dependencies = 
        {
            restartEvent,
            new CharacterStateMachine(transitionsPresenter, states.IdleState),
            new CharacterPhysicsRestart(_rigidbody2D),
            new CharacterTransparency(_spriteRenderer, states.WinState),
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