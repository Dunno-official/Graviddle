using Level.Character.Helpers;
using UnityEngine;

namespace Level.Character.CharacterStateMachine.States
{
    public class DieState : CharacterState
    {
        public DieState(Animator character) : base(character, AnimationsName.Die)
        {
        }

        protected override void OnEnterState()
        {
        }
    }
}
