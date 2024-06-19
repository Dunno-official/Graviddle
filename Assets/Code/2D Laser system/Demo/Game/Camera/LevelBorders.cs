using System;
using UnityEngine;

namespace _2D_Laser_system.Demo.Game.Camera
{
    [Serializable]
    public class LevelBorders 
    {
        [SerializeField] private float _left;
        [SerializeField] private float _right;
        [SerializeField] private float _top;
        [SerializeField] private float _bottom;

        public int Top => Mathf.RoundToInt(_top);
        public int Bottom => Mathf.RoundToInt(_bottom);
        public int Left => Mathf.RoundToInt(_left);
        public int Right => Mathf.RoundToInt(_right);
    }
}