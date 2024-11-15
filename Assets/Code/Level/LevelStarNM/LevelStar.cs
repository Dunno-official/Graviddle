using System;
using Level.Gravitation;
using MonoBehaviourWrapperNM;
using UnityEngine;
using Utils.Physics.PhysicsEventBroadcaster;

namespace Level.LevelStarNM
{
    public class LevelStar : Context
    {
        [SerializeField] private PhysicsEventBroadcaster _physics;
        public event Action StarCollected;

        public void Initialize(StarPickupFeedback pickupFeedback, CharacterGravityState characterCharacterGravityState)
        {
            Bind(new IUnityCallback[]
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
