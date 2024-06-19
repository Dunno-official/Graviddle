﻿using System;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.Data
{
    [Serializable]
    public class ViewData
    {
        [SerializeField] [Min(0)] private float _dissolveTime = 1;
        [SerializeField] private ParticleSystem _hitEffectPrefab;
        [SerializeField] private bool _enableNonHitEffect = true;
        [SerializeField] private int _sortingOrder;
        
        public float DissolveTime => _dissolveTime;
        public int SortingOrder => _sortingOrder;
        public ParticleSystem HitEffectPrefab => _hitEffectPrefab;
        public bool EnableNonHitEffect => _enableNonHitEffect;
    }
}