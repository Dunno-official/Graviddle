using _2D_Laser_system.Code.Laser.Manager;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Utils.Pool.Factory
{
    public class ComponentFactory<T> : IFactory<T> where T : Component
    {
        private readonly T _prefab;
        private int _count;
    
        public ComponentFactory(T prefab)
        {
            _prefab = prefab;
        }
    
        public T Create()
        {
            T result = Object.Instantiate(_prefab, LaserManager.Instance.transform);
            result.transform.localPosition = Vector3.zero;
            result.transform.localRotation = Quaternion.identity;
            result.gameObject.name = $"{_prefab.gameObject.name} {++_count}";
        
            return result;
        }
    }
}