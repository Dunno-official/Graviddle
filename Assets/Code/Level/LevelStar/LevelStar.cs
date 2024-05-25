using System;
using UnityEngine;

public class LevelStar : MonoBehaviourWrapper
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
