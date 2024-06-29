namespace Level.CharacterNM.CharacterStateMachineNM.StateTransitions
{
    public class TransitionsConditions
    {
        public CharacterDeathConditions Death { get; set; }
        public ICondition IsGrounded { get; set; }
        public ICondition Win { get; set; }
        public ICondition Resurrected { get; set; }
        public ICondition IsRunning { get; set; }
        public ICondition IsFalling { get; set; }
        public ICondition IsNotRunning { get; set; }
    }
}