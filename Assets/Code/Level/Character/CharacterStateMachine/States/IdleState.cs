using Level.Character.Helpers;
using UnityEngine;

namespace Level.Character.CharacterStateMachine.States
{
    public class IdleState : CharacterState
    {
        public IdleState(Animator character) : base(character, AnimationsName.Idle)
        {
        }
    }
}