using System.Collections.Generic;

namespace Level.CharacterNM.CharacterStateMachineNM.StateTransitions
{
    public class TransitionsPresenterFactory
    {
        private readonly TransitionsConditions _conditions;
        private readonly CharacterStatesPresenter _states;

        public TransitionsPresenterFactory(CharacterStatesPresenter states, TransitionsConditions conditions)
        {
            _conditions = conditions;
            _states = states;
        }

        public TransitionsPresenter Create()
        {
            TransitionsPresenter transitionPresenter = new();

            foreach (Transition transition in GetTransitions())
            {
                transitionPresenter.AddTransition(transition);
            }

            return transitionPresenter;
        }

        private IEnumerable<Transition> GetTransitions()
        {
            List<Transition> allTransitions = new();

            allTransitions.AddRange(GetTransitionsWithState(_states.WinState, _conditions.Win));
            allTransitions.AddRange(GetTransitionsWithState(_states.DieState, _conditions.Death));
            allTransitions.Add(new Transition(_states.DieState, _states.IdleState, _conditions.Resurrected));
            allTransitions.Add(new Transition(_states.FallState, _states.IdleState, _conditions.IsGrounded));
            allTransitions.Add(new Transition(_states.RunState, _states.IdleState, _conditions.IsNotRunning));
            allTransitions.Add(new Transition(_states.IdleState, _states.RunState, _conditions.IsRunning));
            allTransitions.Add(new Transition(_states.RunState, _states.FallState, _conditions.IsFalling));
            allTransitions.Add(new Transition(_states.IdleState, _states.FallState, _conditions.IsFalling));

            return allTransitions;
        }

        private IEnumerable<Transition> GetTransitionsWithState(CharacterState targetState, ICondition condition)
        {
            List<Transition> transitionsWithState = new();

            foreach (CharacterState stateFrom in _states.GameActiveStates)
            {
                transitionsWithState.Add(new Transition(stateFrom, targetState, condition));
            }

            return transitionsWithState;
        }
    }
}