namespace Level.CharacterNM.CharacterStateMachineNM.Conditions
{
    public class Not : ICondition
    {
        private readonly ICondition _condition;

        public Not(ICondition condition)
        {
            _condition = condition;
        }

        public bool IsTrue()
        {
            return _condition.IsTrue() == false;
        }
    }
}