
namespace _2D_Laser_system.Code.Laser.Utils.Pool
{
    public interface IPoolable
    {
        bool IsActive { get; }
        void Reset();
        void ReturnToPool();
    }
}