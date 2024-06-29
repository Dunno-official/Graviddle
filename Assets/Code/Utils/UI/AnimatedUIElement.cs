using System;
using Cysharp.Threading.Tasks;
using Level.UserInterface;
using UnityEngine;

namespace Utils.UI
{
    [Serializable]
    public class AnimatedUIElement : IAsyncUIElement
    {
        [SerializeField] private Alignment _anchorPreset;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private RectTransform _target;
        [SerializeField] private UIAnimation _showAnimation;
        [SerializeField] private UIAnimation _hideAnimation;
        [SerializeField] private Canvas _canvas;
        
        public void Initialize()
        {
            HiddenUIAlignment alignment = new(_transform, _target, _anchorPreset, _canvas);
            alignment.Execute();
        
            _showAnimation.Initialize(_target.position, _transform);
            _hideAnimation.Initialize(_transform.position, _transform);
        }

        public UniTask Show()
        {
            return _showAnimation.Play();
        }
    
        public UniTask Hide()
        {
            return _hideAnimation.Play();
        }
    }
}