using System;
using UnityEngine;

namespace Utils.Physics.Cast
{
    [Serializable]
    public class CircleCastData
    {
        [SerializeField] private float _radius = 0.6f;
        [SerializeField] private float _distance = 3f;

        public float Radius => _radius;
        public float Distance => _distance;
    }
}