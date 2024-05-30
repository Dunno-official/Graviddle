using LaserSystem2D;
using Level.Gravitation.GravityButton.Link;
using UnityEngine;

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