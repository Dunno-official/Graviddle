
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Link
{
    public class UpdateLink<T> : IUpdate
    {
        private readonly IOutputUpdate<T> _outputUpdate;
        private readonly IInputUpdate<T> _inputUpdate;

        public UpdateLink(IOutputUpdate<T> outputUpdate, IInputUpdate<T> inputUpdate)
        {
            _outputUpdate = outputUpdate;
            _inputUpdate = inputUpdate;
        }

        public void Update()
        {
            T output = _outputUpdate.Update();
            _inputUpdate.Update(output);
        }
    }
}