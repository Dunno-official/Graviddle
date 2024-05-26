using System;
using Level.Restart;
using MonoBehaviourWrapper;
using UnityEngine;
using Utils.Physics.PhysicsEventBroadcaster;

namespace Level.LevelStar
{
    public class LevelStarPickup : ISubscriber, IRestart
    {
        private readonly PhysicsEventBroadcaster _physicsEvent;
        private readonly StarPickupFeedback _feedback;
        private readonly Action _onStarCollected;
        private readonly Transform _transform;

        public LevelStarPickup(PhysicsEventBroadcaster physicsEvent, StarPickupFeedback feedback, Transform transform, Action onStarCollected)
        {
            _onStarCollected = onStarCollected;
            _physicsEvent = physicsEvent;
            _transform = transform;
            _feedback = feedback;
        }

        void ISubscriber.Subscribe()
        {
            _physicsEvent.RegisterOnTriggerEnter<Character.Character>(OnCharacterEntered);
        }

        void ISubscriber.Unsubscribe()
        {
            _physicsEvent.UnRegisterOnTriggerEnter<Character.Character>(OnCharacterEntered);
        }

        private void OnCharacterEntered(Character.Character character)
        {
            _transform.gameObject.SetActive(false);
            
            _feedback.Play(_transform.position);
            
            _onStarCollected?.Invoke();
        }

        void IRestart.Restart()
        {
            _transform.gameObject.SetActive(true);
        }
    }
}