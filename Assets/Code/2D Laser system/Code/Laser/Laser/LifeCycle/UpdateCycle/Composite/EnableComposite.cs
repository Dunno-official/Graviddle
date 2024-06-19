
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Composite
{
    public class EnableComposite : IEnable
    {
        private readonly IEnable[] _elements;

        public EnableComposite(params IEnable[] elements)
        {
            _elements = elements;
        }

        public void Enable()
        {
            foreach (IEnable element in _elements)
            {
                element.Enable();
            }
        }
    }
}