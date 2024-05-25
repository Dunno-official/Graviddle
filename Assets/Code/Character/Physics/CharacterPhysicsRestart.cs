using Level.Restart;
using UnityEngine;

namespace Character.Physics
{
    public class CharacterPhysicsRestart : IRestart
    {
        private readonly Rigidbody2D _rigidbody;

    
        public CharacterPhysicsRestart(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
    

        void IRestart.Restart()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}