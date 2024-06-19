using System;
using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Utils.Pool;
using _2D_Laser_system.Code.Laser.Utils.Pool.Factory;

namespace _2D_Laser_system.Code.Laser.Manager
{
    public class LaserPool
    {
        private readonly Dictionary<Guid, ObjectPool<Laser.Laser>> _pool = new();

        public Laser.Laser GetLaser(Laser.Laser instanceToCopy)
        {
            if (_pool.ContainsKey(instanceToCopy.Id) == false)
            {
                LaserFactory factory = new(instanceToCopy);
                _pool[instanceToCopy.Id] = new ObjectPool<Laser.Laser>(factory);
                _pool[instanceToCopy.Id].Push(instanceToCopy);
            }
        
            return _pool[instanceToCopy.Id].Create();
        }
    
        public void Update()
        {
            foreach (ObjectPool<Laser.Laser> laserPool in _pool.Values)
            {
                laserPool.Update();
            }
        }
    }
}