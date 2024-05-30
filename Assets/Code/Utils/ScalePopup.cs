using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public class ScalePopup : IToggleable
    {
        private readonly Transform _transform;
        private readonly Vector2 _targetScale;
        private readonly float _startScale;
        private readonly float _duration;
        private Tween _animation;

        public ScalePopup(Transform transform, float duration, float startScale, Vector2 targetScale)
        {
            _targetScale = targetScale;
            _startScale = startScale;
            _transform = transform;
            _duration = duration;
        }
    
        public void Show()
        {
            PlayScaleAnimation(_targetScale);
        }

        public void Hide()
        {
            PlayScaleAnimation(new Vector2(_startScale, _startScale));
        }

        private void PlayScaleAnimation(Vector2 targetScale)
        {
            _animation?.Kill();
            _animation = _transform.DOScale(targetScale, _duration).SetLink(_transform.gameObject);
        }
    }
}