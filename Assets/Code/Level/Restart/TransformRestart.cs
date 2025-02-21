﻿using UnityEngine;

namespace Level.Restart
{
    public class TransformRestart : MonoBehaviour, IRestart
    {
        private Quaternion _startRotation;
        private Vector3 _startPosition;
        private Transform _parent;

        private void Start()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            _parent = transform.parent;
        }

        void IRestart.Restart()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotation;
            transform.SetParent(_parent);
        }
    }
}