using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Utils.Pool
{
    public abstract class PoolableMonoBehaviour : MonoBehaviour, IPoolable
    {
        public abstract bool IsActive { get; }
        
        public void Reset()
        {
            gameObject.SetActive(true);
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}