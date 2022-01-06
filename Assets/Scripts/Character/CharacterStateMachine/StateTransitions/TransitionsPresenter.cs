﻿using System.Collections.Generic;


public class TransitionsPresenter
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitionsForState = 
        new Dictionary<CharacterState, List<Transition>>();


    public void AddTransition(Transition transition)
    {
        if (_transitionsForState.ContainsKey(transition.StateFrom) == false)
        {
            _transitionsForState[transition.StateFrom] = new List<Transition>();
        }

        _transitionsForState[transition.StateFrom].Add(transition);
    }


    public TransitionResult Transit(CharacterState currentState)
    {
        var transitionResult = new TransitionResult();

        if (_transitionsForState.ContainsKey(currentState))
        {
            foreach (Transition transition in _transitionsForState[currentState])
            {
                if (transition.CheckIfTransitionHappened())
                {
                    transitionResult = new TransitionResult(transition.StateTo);
                    transition.Clear();
                    break;
                }
            }
        }

        return transitionResult;
    }
}