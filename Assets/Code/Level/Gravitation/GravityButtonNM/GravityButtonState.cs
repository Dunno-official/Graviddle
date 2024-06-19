using System;
using MonoBehaviourWrapperNM;

namespace Level.Gravitation.GravityButtonNM
{
    public class GravityButtonState : IInitializable, IDisposable
    {
        private readonly GravityButtonEvents _events;

        public GravityButtonState(GravityButtonEvents events)
        {
            _events = events;
        }
        
        public bool IsEnabled { get; private set; }

        public void Initialize()
        {
            _events.Toggled += ChangeState;
        }

        public void Dispose()
        {
            _events.Toggled -= ChangeState;
        }

        private void ChangeState(bool state)
        {
            IsEnabled = state;
        }
    }
}