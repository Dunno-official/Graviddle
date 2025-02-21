﻿using Level.Restart;
using UnityEngine;

namespace Level.ClosedPathMotion
{
    public class ClosedPathMotion : MonoBehaviour, IRestart
    {
        [SerializeField] private ClosedPathMotionCalculator _motionCalculator;
        [SerializeField] private Transform _targetTransform;

        private Vector2 _startPosition = Vector2.zero;
        private Vector2 _targetPosition = Vector2.zero;

        private void Start()
        {
            _targetPosition = _targetTransform.position;
            _startPosition = transform.position;

            _motionCalculator.Initialize();
        }

        private void Update()
        {
            float lerp = _motionCalculator.EvaluateLerpPosition();
            transform.position = Vector2.Lerp(_startPosition, _targetPosition, lerp);
        }
    
        void IRestart.Restart()
        {
            _motionCalculator.Restart();
        }
    }
}