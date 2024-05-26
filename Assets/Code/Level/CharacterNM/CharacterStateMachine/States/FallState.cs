using Level.CharacterNM.Helpers;
using UnityEngine;

namespace Level.CharacterNM.CharacterStateMachine.States
{
    public class FallState : CharacterState
    {
        public FallState(Animator character) : base(character, AnimationsName.Fall)
        {
        }
    }
}