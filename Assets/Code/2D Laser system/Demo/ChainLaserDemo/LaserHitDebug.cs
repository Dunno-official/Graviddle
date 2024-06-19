using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using _2D_Laser_system.Code.Laser.Utils;
using UnityEngine;

namespace _2D_Laser_system.Demo.ChainLaserDemo
{
    public class LaserHitDebug : MonoBehaviour, ILaserStay
    {
        [SerializeField] private float _size = 0.2f;
        private Material _debugMaterial;
        private Mesh _quad;

        private void Start()
        {
            _debugMaterial = Resources.Load<Material>("DebugMaterial");
            _quad = MeshExtensions.CreateQuad(_size, _size);
        }

        public void OnLaserStay(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            foreach (RaycastHit2D hit in hits)
            {
                Graphics.DrawMesh(_quad, hit.point, Quaternion.identity, _debugMaterial, 0);
            }
        }
    }
}