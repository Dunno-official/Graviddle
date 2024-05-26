using System;
using UnityEngine;

namespace Level.Character.CharacterMovement.CharacterInputNM
{
    public class DesktopInput : CharacterInput
    {
        public override Vector2 GetDirection()
        {
            int input = -Convert.ToInt32(Input.GetKey(KeyCode.A));

            if (input == 0)
            {
                input = Convert.ToInt32(Input.GetKey(KeyCode.D));
            }
            
            return new Vector2(input, 0);
        }
    }
}