
using Level.CharacterNM.CharacterStateMachineNM;

namespace Level.CharacterNM
{
    public class PollingEvent : ICondition
    {
        private bool _eventHappened;

        public bool IsTrue()
        {
            bool result = _eventHappened;

            _eventHappened = false;

            return result;
        }

        public void Invoke()
        {
            _eventHappened = true;
        }
    }
}