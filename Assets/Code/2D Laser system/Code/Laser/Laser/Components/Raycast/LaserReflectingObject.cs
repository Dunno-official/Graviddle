using _2D_Laser_system.Code.Laser.Manager;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.Components.Raycast
{
    [RequireComponent(typeof(Collider2D))]
    public class LaserReflectingObject : MonoBehaviour
    {
        private void Start()
        {
            Collider2D[] colliders = GetComponents<Collider2D>();
            LaserManager.Instance.ReflectingColliders.Add(colliders);
        }
    }
}