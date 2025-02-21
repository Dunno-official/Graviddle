﻿using UnityEngine;

namespace Level.Obstacles.ArrowTrap
{
    public class Arrow : MonoBehaviour
    {
        private readonly float _speed = 10f;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, _speed * Time.deltaTime);
        }
    }
}