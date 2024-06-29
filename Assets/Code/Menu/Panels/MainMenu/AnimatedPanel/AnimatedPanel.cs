using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Extensions;
using Level.UserInterface;
using Level.UserInterface.Panels;
using UnityEngine;
using Utils.UI;

namespace Menu.MainMenu.AnimatedPanel
{
    public abstract class AnimatedPanel : Panel
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] protected UIBlocker UIBlocker;
        [SerializeField] private AnimatedUIElement[] _animatedElements;
        [SerializeReference] private IAsyncUIElement[] _asyncUIElements;
        private IEnumerable<UniTask> _onShowAnimation;
        private IEnumerable<UniTask> _onHideAnimation;
    
        public override UniTask Initialize()
        {
            _asyncUIElements.ForEach(x => x.Initialize());
            _onShowAnimation = _asyncUIElements.Select(element => element.Show());
            _onHideAnimation = _asyncUIElements.Select(element => element.Hide());

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