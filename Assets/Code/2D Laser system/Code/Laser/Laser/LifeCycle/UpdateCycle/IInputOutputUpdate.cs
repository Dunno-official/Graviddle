
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle
{
    public interface IInputOutputUpdate<in TInput, out TOutput>
    {
        TOutput Update(TInput input);
    }
}