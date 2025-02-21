using System;
using DG.Tweening;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Level.UserInterface.Panels.WinPanel
{
    [Serializable]
    public class WinAnimation
    {
        [SerializeField] private Image _image;
        [SerializeField] private WinEffects _effects;
        [SerializeField] private Image _levelScore;
        [SerializeField] private Button[] _buttons;
    
        private readonly float _animationDuration = 2f;
        private readonly float _startWaitTime = 2.5f;
        private readonly float _targetFade = 0.6f;
        private readonly Vector2 _targetPosition = Vector2.zero;

        public void Initialize(Reward reward)
        {
            _effects.Initialize(reward);
        }
        
        public void Play()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendInterval(_startWaitTime);
            sequence.Append(_levelScore.transform.DOLocalMove(_targetPosition, _animationDuration).SetEase(Ease.OutBack));
            sequence.Join(_image.DOFade(_targetFade, _animationDuration));
            sequence.OnComplete(ActivateEffects);
        }

        private async void ActivateEffects()
        {
            await _effects.ActivateEffects();
            _buttons.ForEach(button => button.interactable = true);
        }
    }
}