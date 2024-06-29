using Level.Obstacles;
using Utils.Physics;

namespace Level.CharacterNM
{
    public class CharacterObstacleDeath : IDeathCondition
    {
        private readonly CollisionsList _collisionsList;

        public CharacterObstacleDeath(CollisionsList collisionsList)
        {
            _collisionsList = collisionsList;
        }

        public bool IsDead(out string reason)
        {
            reason = string.Empty;
            bool isDead = _collisionsList.TryGetCollision(out Obstacle obstacle);

            if (isDead)
            {
                reason = $"Died from {obstacle.name}";   
            }

            return isDead;
        }
    }
}