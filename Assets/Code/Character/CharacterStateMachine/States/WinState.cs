using System;
using Character.Helpers;
using UnityEngine;

namespace Character.CharacterStateMachine.States
{
    public class WinState : CharacterState
    {
        private readonly Rigidbody2D _rigidbody;
        public event Action CharacterWon;


        public WinState(Animator character) : base(character, AnimationsName.Fall)
        {
            _rigidbody = character.GetComponent<Rigidbody2D>();
        }


        protected override void OnEnterState()
        {
            CharacterWon?.Invoke();

            _rigidbody.velocity = Vector2.zero;
            _rigidbody.isKinematic = true;
        }
    }
}