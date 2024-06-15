using System;
using UnityEngine;

namespace Level.CameraNM
{
    [Serializable]
    public class CurveAnimationData
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _time = 0.4f;

        public AnimationCurve Curve => _curve;
        public float Time => _time;
    }
}