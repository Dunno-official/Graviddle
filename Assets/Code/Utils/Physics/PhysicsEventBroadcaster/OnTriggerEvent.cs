using System;
using UnityEngine;

namespace Utils.Physics.PhysicsEventBroadcaster
{
    class OnTriggerEvent<T> : IOnTriggerEvent where T : MonoBehaviour 
    {
        public readonly Action<T> Callback;

        public OnTriggerEvent(Action<T> callback)
        {
            Callback = callback;
        }
    
        public void Invoke(Component callbackObject)
        {
            Callback?.Invoke((T)callbackObject);
        }
    }
}