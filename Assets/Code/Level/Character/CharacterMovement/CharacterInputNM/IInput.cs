using Level.Character.Helpers;
using UnityEngine;

namespace Level.Character.CharacterMovement.CharacterInputNM
{
    public abstract class CharacterInput
    {
        public abstract Vector2 GetDirection();

        public virtual MovementState GetState()
        {
            return GetDirection().x switch
            {
                -1 => MovementState.Left,
                1 => MovementState.Right,
                _ => MovementState.Stop
            };
        }
    }
}