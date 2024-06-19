using UnityEngine;

namespace _2D_Laser_system.Demo.ChainLaserDemo
{
    public class ZRotation : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(0, 0, _speed * Time.deltaTime);
        }
    }
}