using Level.CharacterNM.Helpers;
using UnityEngine;

namespace Level.CharacterNM.CharacterStateMachine.States
{
    public class IdleState : CharacterState
    {
        public IdleState(Animator character) : base(character, AnimationsName.Idle)
        {
        }
    }
}