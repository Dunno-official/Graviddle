using Level.CharacterNM.Helpers;
using UnityEngine;

namespace Level.CharacterNM.CharacterStateMachineNM.States
{
    public class DieState : CharacterState
    {
        public DieState(Animator character) : base(character, AnimationsName.Die)
        {
        }

        protected override void OnEnter()
        {
        }
    }
}
