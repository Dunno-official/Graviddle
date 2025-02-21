﻿using System.Collections.Generic;
using System.Linq;

namespace Level.CharacterNM.CharacterStateMachineNM.StateTransitions
{
    public class TransitionsPresenter
    {
        private readonly Dictionary<CharacterState, List<Transition>> _transitions = new();

        public void AddTransition(Transition transition)
        {
            if (_transitions.ContainsKey(transition.StateFrom) == false)
            {
                _transitions.Add(transition.StateFrom, new List<Transition>());
            }

            _transitions[transition.StateFrom].Add(transition);
        }

        public Transition GetTransition(CharacterState stateFrom, CharacterState stateTo)
        {
            return _transitions[stateFrom].First(transition => transition.StateTo == stateTo);
        }

        public CharacterState Transit(CharacterState currentState)
        {
            CharacterState newState = currentState;

            if (_transitions.ContainsKey(currentState))
            {
                foreach (Transition transition in _transitions[currentState])
                {
                    if (transition.CheckCondition())
                    {
                        newState = transition.StateTo;
                        break;
                    }
                }
            }

            return newState;
        }
    }
}