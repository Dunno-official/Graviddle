
namespace _2D_Laser_system.Code.Laser.Utils.Pool.Factory
{
    public interface IFactory<out T>
    {
        T Create();
    }
}