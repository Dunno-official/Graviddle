using System.Collections.Generic;
using System.Collections.ObjectModel;
using Character.CharacterMovement;
using Character.CharacterStateMachine.States;
using UnityEngine;

namespace Character.CharacterStateMachine
{
    public class CharacterStatesPresenter
    {
        public readonly FallState FallState;
        public readonly DieState DieState;
        public readonly WinState WinState;
        public readonly IdleState IdleState;
        public readonly RunState RunState;
        public readonly ReadOnlyCollection<CharacterState> GameActiveStates;


        public CharacterStatesPresenter(Animator character, CharacterMoveDirection characterMoveDirection)
        {
            FallState = new FallState(character);
            DieState = new DieState(character);
            WinState = new WinState(character);
            IdleState = new IdleState(character);
            RunState = new RunState(character, characterMoveDirection);

            GameActiveStates = new List<CharacterState>
            {
                FallState, IdleState, RunState
            }.AsReadOnly();
        }
    }
}
 
