using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Level.UserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.UI
{
    [Serializable]
    public class ImageFading : IAsyncUIElement
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;
        [SerializeField] private float _targetFade;
        private Tween _animation;
        
        public async UniTask Show()
        {
            await Fade(_targetFade);
        }

        public async UniTask Hide()
        {
            await Fade(0);
        }

        private async UniTask Fade(float target)
        {
            _animation?.Kill();
            _animation = _image.DOFade(target, _duration);

            await _animation.ToUniTask();
        }
    }
}