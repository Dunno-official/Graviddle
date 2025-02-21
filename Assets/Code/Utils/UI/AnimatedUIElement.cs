﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Utils.UI
{
    [Serializable]
    public class AnimatedUIElement
    {
        [SerializeField] private Alignment _anchorPreset;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private RectTransform _target;
        [SerializeField] private UIAnimation _showAnimation;
        [SerializeField] private UIAnimation _hideAnimation;

        public void Initialize(Canvas canvas)
        {
            HiddenUIAlignment alignment = new(_transform, _target, _anchorPreset, canvas);
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