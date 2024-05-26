using Level.CharacterNM.Helpers;
using Level.Gravitation;
using UnityEngine;

namespace Level.CharacterNM.CharacterMovement.CharacterInputNM
{
    public class GravityInput : CharacterInput
    {
        private readonly IGravityState _gravityState;
        private readonly CharacterInput _input;

        public GravityInput(IGravityState gravityState, CharacterInput input)
        {
            _gravityState = gravityState;
            _input = input;
        }

        public override Vector2 GetDirection()
        {
            return _gravityState.Data.Rotation * _input.GetDirection();
        }

        public override MovementState GetState()
        {
            return _input.GetState();
        }
    }
}