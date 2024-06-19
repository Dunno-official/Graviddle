using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser
{
    public interface ILaserKeyPointProvider
    {
        Vector2 this[int index] { get; }
        int Count { get; }
    }
}