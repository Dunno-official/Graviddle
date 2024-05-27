using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.Helpers;
using MonoBehaviourWrapperNM;
using UnityEngine;

namespace Level.CharacterNM.CharacterMovement
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