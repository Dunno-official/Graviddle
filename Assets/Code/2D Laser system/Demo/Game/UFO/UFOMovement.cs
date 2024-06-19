using System;
using UnityEngine;

namespace _2D_Laser_system.Demo.Game.UFO
{
    [Serializable]
    public class UFOMovement 
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Update(Vector2 input)
        {
            _rigidbody.MovePosition(_rigidbody.position + input * (_speed * Time.deltaTime));
        }
    }
}