using UnityEngine;
using Utils.Physics;

namespace Level.CharacterNM.CharacterStateMachineNM.Conditions
{
    public class CollisionCondition<T> : ICondition where T : MonoBehaviour
    {
        private readonly CollisionsList _collisions;

        public CollisionCondition(CollisionsList collisions)
        {
            _collisions = collisions;
        }

        public bool IsTrue()
        {
            return _collisions.CheckCollision<T>();
        }
    }
}