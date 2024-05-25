using Character.Helpers;
using UnityEngine;

namespace Character.CharacterStateMachine.States
{
    public class IdleState : CharacterState
    {
        public IdleState(Animator character) : base(character, AnimationsName.Idle)
        {
        }
    }
}