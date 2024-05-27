using System.Collections.Generic;
using System.Collections.ObjectModel;
using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.CharacterStateMachine.States;
using UnityEngine;
using Utils.Physics.Cast;

namespace Level.CharacterNM.CharacterStateMachine
{
    public class CharacterStatesPresenter
    {
        public readonly ReadOnlyCollection<CharacterState> GameActiveStates;
        public readonly IdleState IdleState;
        public readonly FallState FallState;
        public readonly DieState DieState;
        public readonly WinState WinState;
        public readonly RunState RunState;

        public CharacterStatesPresenter(Animator character, CharacterInput input, CircleCastData circleCastData)
        {
            FallState = new FallState(character);
            DieState = new DieState(character);
            WinState = new WinState(character);
            IdleState = new IdleState(character);
            RunState = new RunState(character, input, 3.75f, circleCastData);

            GameActiveStates = new List<CharacterState>
            {
                FallState, IdleState, RunState
            }.AsReadOnly();
        }
    }
}
 
