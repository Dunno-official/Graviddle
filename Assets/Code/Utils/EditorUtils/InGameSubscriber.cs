using MonoBehaviourWrapperNM;
using UnityEngine.Device;

namespace Utils.EditorUtils
{
    public class InGameSubscriber : ISubscriber
    {
        private readonly ISubscriber _subscriber;

        public InGameSubscriber(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Subscribe()
        {
            if (Application.isEditor == false)
            {
                _subscriber.Subscribe();   
            }
        }

        public void Unsubscribe()
        {
            if (Application.isEditor == false)
            {
                _subscriber.Unsubscribe();
            }
        }
    }
}