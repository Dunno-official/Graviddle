using Level.CharacterNM.CharacterMovement.CharacterInputNM;
using Level.CharacterNM.Helpers;

namespace Level.CharacterNM.CharacterStateMachineNM.Conditions
{
    public class IsRunning : ICondition
    {
        private readonly CharacterInput _input;

        public IsRunning(CharacterInput input)
        {
            _input = input;
        }

        public bool IsTrue()
        {
            return _input.GetState() != MovementState.Stop;
        }
    }
}