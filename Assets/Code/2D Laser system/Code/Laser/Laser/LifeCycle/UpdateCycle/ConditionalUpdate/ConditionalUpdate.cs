
namespace _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.ConditionalUpdate
{
    public class ConditionalUpdate : IUpdate
    {
        private readonly IUpdateCondition _updateCondition;
        private readonly IUpdate _updateIfFalse;
        private readonly IUpdate _updateIfTrue;

        public ConditionalUpdate(IUpdateCondition updateCondition, IUpdate updateIfTrue) 
            : this(updateCondition, updateIfTrue, new UpdateDummy())
        {
        }
        
        public ConditionalUpdate(IUpdateCondition updateCondition, IUpdate updateIfTrue, IUpdate updateIfFalse)
        {
            _updateCondition = updateCondition;
            _updateIfFalse = updateIfFalse;
            _updateIfTrue = updateIfTrue;
        }

        public void Update()
        {
            if (_updateCondition.IsTrue())
            {
                _updateIfTrue.Update();
            }
            else
            {
                _updateIfFalse.Update();
            }
        }
    }
}