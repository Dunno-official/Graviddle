using Level.CharacterNM.CharacterStateMachineNM;

namespace Level.CharacterNM
{
    public class CharacterDeathConditions : ICondition
    {
        private readonly IDeathCondition[] _deathCondition;

        public CharacterDeathConditions(IDeathCondition[] deathCondition)
        {
            _deathCondition = deathCondition;
        }

        public string Reason { get; private set; }

        public bool IsTrue()
        {
            Reason = string.Empty;
            
            foreach (IDeathCondition condition in _deathCondition)
            {
                if (condition.IsDead(out string reason))
                {
                    Reason = reason;
                    return true;
                }
            }

            return false;
        }
    }
}