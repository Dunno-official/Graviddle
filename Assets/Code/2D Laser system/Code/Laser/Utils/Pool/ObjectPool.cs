using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Utils.Pool.Factory;

namespace _2D_Laser_system.Code.Laser.Utils.Pool
{
    public class ObjectPool<T> : IFactory<T> where T : IPoolable
    {
        private readonly IFactory<T> _factory;
        private readonly Stack<T> _pool = new();
        private readonly List<T> _activeObjects = new();
    
        public ObjectPool(IFactory<T> factory)
        {
            _factory = factory;
        }

        public void Push(T instance)
        {
            _pool.Push(instance);
        }

        public T Create()
        {
            T instance = SpawnOrPop();
            _activeObjects.Add(instance);
            instance.Reset();

            return instance;
        }

        private T SpawnOrPop()
        {
            return _pool.Count == 0 ? _factory.Create() : _pool.Pop();
        }

        public void Update()
        {
            for (int i = 0 ; i < _activeObjects.Count; ++i)
            {
                if (_activeObjects[i].IsActive == false)
                {
                    _activeObjects[i].ReturnToPool();
                    _pool.Push(_activeObjects[i]);
                    _activeObjects.Remove(_activeObjects[i]);
                }
            }
        }
    }
}