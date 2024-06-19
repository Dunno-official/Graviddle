
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Composite
{
    public class UpdateComposite : IUpdate
    {
        private readonly IUpdate[] _updates;

        public UpdateComposite(params IUpdate[] updates)
        {
            _updates = updates;
        }
        
        public void Update()
        {
            foreach (IUpdate update in _updates)
            {
                update.Update();
            }
        }
    }
}