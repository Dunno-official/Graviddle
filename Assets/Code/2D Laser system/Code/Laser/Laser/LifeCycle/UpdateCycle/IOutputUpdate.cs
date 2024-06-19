
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle
{
    public interface IOutputUpdate<out TOutput>
    {
        TOutput Update();
    }
}