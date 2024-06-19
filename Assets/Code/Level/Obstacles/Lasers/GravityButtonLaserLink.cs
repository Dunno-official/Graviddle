using _2D_Laser_system.Code.Laser.Laser;
using Level.Gravitation.GravityButtonNM.Link;
using UnityEngine;

namespace Level.Obstacles.Lasers
{
    public class GravityButtonLaserLink : GravityButtonLink
    {
        [SerializeField] private LaserBase _laserBase;

        protected override void Enable()
        {
            _laserBase.Enable();
        }

        protected override void Disable()
        {
            _laserBase.Disable();
        }
    }
}