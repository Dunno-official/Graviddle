using Level.Restart;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.Gravitation.GravityButtonNM
{
    public class GravityButtonLiftForce : IRestart, ISubscriber, IUpdate
    {
        private readonly GravityButtonEvents _events;
        private readonly GravityButtonData _data;
        private readonly Rigidbody2D _rigidbody;
        private bool _isLifting;

        public GravityButtonLiftForce(GravityButtonEvents events, GravityButtonData data, Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _events = events;
            _data = data;
        }

        void ISubscriber.Subscribe()
        {
            _events.Toggled += ResetLiftForce;
        }

        void ISubscriber.Unsubscribe()
        {
            _events.Toggled += ResetLiftForce;
        }

        void IUpdate.Update()
        {
            if (_isLifting)
            {
                _rigidbody.velocity += (Vector2)_rigidbody.transform.up * (_data.LiftingSpeed * Time.deltaTime);
            }
        }

        void IRestart.Restart()
        {
            ResetLiftForce(enableLiftForce: false); 
        }

        private void ResetLiftForce(bool enableLiftForce)
        {
            _isLifting = enableLiftForce;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}