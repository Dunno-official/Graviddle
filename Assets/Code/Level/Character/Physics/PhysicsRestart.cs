using Level.Restart;
using UnityEngine;

namespace Level.Character.Physics
{
    public class PhysicsRestart : MonoBehaviour, IRestart
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        void IRestart.Restart()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}