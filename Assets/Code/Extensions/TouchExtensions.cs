﻿using UnityEngine;

namespace Extensions
{
    public static class TouchExtensions
    {
        public static Vector2 GetPreviousTouchPosition(this Touch touch)
        {
            return touch.position - touch.deltaPosition;
        }
    }
}