using Cysharp.Threading.Tasks;

namespace Level.UserInterface.Panels
{
    public abstract class Panel : UIElement
    {
        public virtual async UniTask Initialize()
        {
            await UniTask.Yield();
        }

        public async UniTask Show()
        {
            Enable();
            await OnShow();
        }

        public async UniTask Hide()
        {
            await OnHide();
            Disable();
        }

        protected virtual async UniTask OnShow() { await UniTask.Yield(); }
        protected virtual async UniTask OnHide() { await UniTask.Yield(); }
    }
}