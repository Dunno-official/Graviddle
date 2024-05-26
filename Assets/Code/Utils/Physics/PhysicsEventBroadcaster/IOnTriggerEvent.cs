using UnityEngine;

namespace Utils.Physics.PhysicsEventBroadcaster
{
    interface IOnTriggerEvent
    {
        void Invoke(Component component);
    }
}