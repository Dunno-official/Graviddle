
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Composite
{
    public class DisableComposite : IDisable
    {
        private readonly IDisable[] _elements;

        public DisableComposite(params IDisable[] elements)
        {
            _elements = elements;
        }

        public void Disable()
        {
            foreach (IDisable element in _elements)
            {
                element.Disable();
            }
        }
    }
}