namespace Level.CharacterNM
{
    public interface IDeathCondition
    {
        bool IsDead(out string reason);
    }
}