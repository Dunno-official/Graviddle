using Level.CharacterNM.Helpers;
using UnityEngine;

namespace Level.CharacterNM.CharacterMovement.CharacterInputNM
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