using Level.Character.CharacterMovement.CharacterInputNM;
using Level.Character.Helpers;
using MonoBehaviourWrapper;
using UnityEngine;

namespace Level.Character.CharacterMovement
{
    public class CharacterSpriteFlipping : IUpdate 
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly CharacterInput _input;

        public CharacterSpriteFlipping(SpriteRenderer spriteRenderer, CharacterInput input)
        {
            _spriteRenderer = spriteRenderer;
            _input = input;
        }

        public void Update()
        {
            if (_input.GetState() != MovementState.Stop)
            {
                _spriteRenderer.flipX = _input.GetState() == MovementState.Left;   
            }
        }
    }
}