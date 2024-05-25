using System;
using UnityEngine;

namespace Level.Camera
{
    [Serializable]
    public class CameraRotationData
    {
        [SerializeField] private AnimationCurve _rotationCurve;
        [SerializeField] private float _time = 0.4f;

        public AnimationCurve Curve => _rotationCurve;
        public float Time => _time;
    }
}