using System.Collections.Generic;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.Components.Interaction
{
    public interface ILaserEntered 
    {
        void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits);
    }
}