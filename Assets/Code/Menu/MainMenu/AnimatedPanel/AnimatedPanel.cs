using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Level.UI.Panels;
using UnityEngine;
using Utils.UI;

namespace Menu.MainMenu.AnimatedPanel
{
    public abstract class AnimatedPanel : Panel
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] protected UIBlocker UIBlocker;
        [SerializeField] private AnimatedUIElement[] _animatedElements;
        private IEnumerable<UniTask> _onShowAnimation;
        private IEnumerable<UniTask> _onHideAnimation;
    
        public override UniTask Initialize()
        {
            foreach (AnimatedUIElement animatedElement in _animatedElements)
            {
                animatedElement.Initialize(_canvas);
            }

            _onShowAnimation = _animatedElements.Select(element => element.Show());
            _onHideAnimation = _animatedElements.Select(element => element.Hide());

            return base.Initialize();
        }

        protected override async UniTask OnShow()
        {
            await PlayAnimation(_onShowAnimation);
        }

        protected override async UniTask OnHide()
        {
            await PlayAnimation(_onHideAnimation);
        }

        private async UniTask PlayAnimation(IEnumerable<UniTask> tasks)
        {
            UIBlocker.Enable();

            await UniTask.WhenAll(tasks);

            UIBlocker.Disable();
        }
    }
}