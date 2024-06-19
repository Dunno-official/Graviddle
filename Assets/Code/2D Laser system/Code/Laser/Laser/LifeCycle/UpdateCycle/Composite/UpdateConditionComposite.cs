using System.Linq;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.ConditionalUpdate;

namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Composite
{
    public class UpdateConditionComposite : IUpdateCondition
    {
        private readonly IUpdateCondition[] _updateConditions;

        public UpdateConditionComposite(IUpdateCondition[] updateConditions)
        {
            _updateConditions = updateConditions;
        }

        public bool IsTrue()
        {
            return _updateConditions.All(updateCondition => updateCondition.IsTrue());
        }
    }
}