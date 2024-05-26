using System;
using Level.Gravitation;
using MonoBehaviourWrapper;
using UnityEngine;
using Utils.Physics.PhysicsEventBroadcaster;

namespace Level.LevelStar
{
    public class LevelStar : MonoBehaviourWrapper.MonoBehaviourWrapper
    {
        [SerializeField] private PhysicsEventBroadcaster _physics;
        public event Action StarCollected;

        public void Initialize(StarPickupFeedback pickupFeedback, CharacterGravityState characterCharacterGravityState)
        {
            SetDependencies(new IUnityCallback[]
            {
                new LevelStarPickup(_physics, pickupFeedback, transform, CollectStar),
                new GravityRotation(characterCharacterGravityState, transform),
            });
        }

        private void CollectStar()
        {
            StarCollected?.Invoke();
        }
    }
}
