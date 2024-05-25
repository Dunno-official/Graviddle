﻿
using Character;

namespace Level.Restart
{
    public class RestartEvent : IRestart
    {
        private readonly EventTransit _eventTransit = new EventTransit();


        public bool CheckRestart()  
        {
            return _eventTransit.CheckIfEventHappened();
        }
    
    
        void IRestart.Restart()
        {
            _eventTransit.Invoke();
        }
    }
}