using Level.CharacterNM.Helpers;
using Level.Gravitation;
using Level.UI.Panels.GameplayPanel.MovementButtons;
using MonoBehaviourWrapper;
using UnityEngine;

namespace Level.CharacterNM.CharacterMovement
{
    public class CharacterMovementDirection : IUpdate
    {
        private readonly IGravityState _gravityState;
        private readonly InputButton _rightButton;
        private readonly InputButton _leftButton;

        public CharacterMovementDirection(IGravityState gravityState, InputButton rightButton, InputButton leftButton)
        {
            _gravityState = gravityState;
            _rightButton = rightButton;
            _leftButton = leftButton;
        }

        public Vector2 Direction { get; private set; }

        void IUpdate.Update()
        {
            MovementState state = MovementState.Stop;
        
            TryChangeState(_leftButton, ref state, MovementState.Left);
            TryChangeState(_rightButton, ref state, MovementState.Right);

            Direction = _gravityState.Data.Rotation * (Vector2.right * (int) state);
        }

        private void TryChangeState(InputButton inputButton, ref MovementState state, MovementState targetState)
        {
            if (inputButton.IsTouching)
            {
                state = targetState;
            }
        }
    }
}