using System;
using UnityEngine;

namespace Level.Gravitation.GravityButton
{
    [Serializable]
    public class GravityButtonData
    {
        [SerializeField] private float _topExtremePoint = 0.36f;
        [SerializeField] private float _bottomExtremePoint;
        [SerializeField] private float _bottomClampPoint;
        [SerializeField] private float _speed = 0.05f;

        public float TopExtremePoint => _topExtremePoint;
        public float BottomExtremePoint => _bottomExtremePoint;
        public float BottomClampPoint => _bottomClampPoint;
        public float LiftingSpeed => _speed;
    }
}