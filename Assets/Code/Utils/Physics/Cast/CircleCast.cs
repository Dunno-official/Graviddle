using UnityEngine;

namespace Utils.Physics
{
    public class CircleCast<T> where T : MonoBehaviour
    {
        private readonly CircleCastData _data;
        private readonly ContactFilter2D _contactFilter2D;
        private readonly RaycastHit2D[] _hits;

        public CircleCast(int bufferSize, CircleCastData data, ContactFilter2D contactFilter2D = new())
        {
            _hits = new RaycastHit2D[bufferSize];
            _contactFilter2D = contactFilter2D;
            _data = data;
        }

        public HitResult<T> Fetch(Vector2 position, Vector2 direction)
        {
            int size = Physics2D.CircleCast(position, _data.Radius, direction, _contactFilter2D, _hits, _data.Distance);

            for (int i = 0; i < size; ++i)
            {
                if (_hits[i].collider.TryGetComponent(out T output))
                {
                    return new HitResult<T>(_hits[i], true, output);
                }
            }

            return new HitResult<T>(default, false, default);
        }
    }
}