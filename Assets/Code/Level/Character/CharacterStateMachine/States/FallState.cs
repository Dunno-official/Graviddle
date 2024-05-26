using System;
using Level.Character.Helpers;
using UnityEngine;

namespace Level.Character.CharacterStateMachine.States
{
    public class FallState : CharacterState
    {
        public event Action CharacterFalling;

        public FallState(Animator character) : base(character, AnimationsName.Fall)
        {
        }
    
        protected override void OnEnterState()
        {
            CharacterFalling?.Invoke();
        }
    }
}