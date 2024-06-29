using System;

namespace Level.CharacterNM.CharacterStateMachineNM.StateTransitions
{
    public class Transition
    {
        public readonly CharacterState StateFrom;
        public readonly CharacterState StateTo;
        private readonly ICondition _condition;

        public Transition(CharacterState stateFrom, CharacterState stateTo, ICondition condition)
        {
            _condition = condition;
            StateFrom = stateFrom;
            StateTo = stateTo;
        }

        public event Action TransitionHappened;

        public bool CheckCondition()
        {
            bool transitionHappened = _condition.IsTrue();

            if (transitionHappened)
            {
                TransitionHappened?.Invoke();
            }

            return transitionHappened;
        }
    }
}