
using MonoBehaviourWrapperNM;

namespace Utils
{
    public abstract class TogglingComponent : IUpdate, ILateUpdate, IFixedUpdate
    {
        public bool IsActive = true;
    
        void IUpdate.Update()
        {
            if (IsActive)
            {
                OnUpdate();
            }
        }

        public void LateUpdate()
        {
            if (IsActive)
            {
                OnLateUpdate();
            }
        }

        public void FixedUpdate()
        {
            if (IsActive)
            {
                OnFixedUpdate();
            }
        }

        protected virtual void OnFixedUpdate() {}
        protected virtual void OnUpdate() {}
        protected virtual void OnLateUpdate() {}
    }
}