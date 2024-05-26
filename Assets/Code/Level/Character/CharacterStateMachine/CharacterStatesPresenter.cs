using System.Collections.Generic;
using System.Collections.ObjectModel;
using Level.Character.CharacterMovement;
using Level.Character.CharacterMovement.CharacterInputNM;
using Level.Character.CharacterStateMachine.States;
using UnityEngine;
using Utils.Physics;

namespace Level.Character.CharacterStateMachine
{
    public class CharacterStatesPresenter
    {
        public readonly FallState FallState;
        public readonly DieState DieState;
        public readonly WinState WinState;
        public readonly IdleState IdleState;
        public readonly RunState RunState;
        public readonly ReadOnlyCollection<CharacterState> GameActiveStates;

        public CharacterStatesPresenter(Animator character, CharacterInput input)
        {
            FallState = new FallState(character);
            DieState = new DieState(character);
            WinState = new WinState(character);
            IdleState = new IdleState(character);
            RunState = new RunState(character, input, 3.75f, new CircleCastData());

            GameActiveStates = new List<CharacterState>
            {
                FallState, IdleState, RunState
            }.AsReadOnly();
        }
    }
}
 
