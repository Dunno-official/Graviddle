using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Level.UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        public virtual async UniTask Initialize()
        {
            await UniTask.Yield();
        }
    
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
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