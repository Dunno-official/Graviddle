using System;
using Character.Helpers;
using UnityEngine;

namespace Level.UI.Parallax.GameParallax
{
    [Serializable]
    public class ParallaxCameraPosition 
    {
        [SerializeField] private UnityEngine.Camera _mainCamera;


        public float GetCameraPosition(GravityDirection gravityDirection)
        {
            return gravityDirection switch
            {
                GravityDirection.Down => _mainCamera.transform.position.x,
                GravityDirection.Up => -_mainCamera.transform.position.x,
                GravityDirection.Left => -_mainCamera.transform.position.y,
                GravityDirection.Right => _mainCamera.transform.position.y,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}