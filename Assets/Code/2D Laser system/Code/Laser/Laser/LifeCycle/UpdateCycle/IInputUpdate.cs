
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle
{
    public interface IInputUpdate<in TInput>
    {
        void Update(TInput input);
    }
}