using DG.Tweening;
using UnityEngine;

namespace Level.Tutorial.PointerAnimation
{
    public class PointerAnimation
    {
        private readonly PointerAnimationData _data;
        private readonly Vector2 _targetSlidePosition;
        private readonly Quaternion _startRotation;
        private readonly Vector2 _startPosition;
        private Sequence _animation;

        public PointerAnimation(PointerAnimationData data)
        {
            _data = data;
            _startPosition = _data.SpriteRenderer.transform.position;
            _targetSlidePosition = _startPosition + _data.TargetOffsetDistance;
            _startRotation = _data.SpriteRenderer.transform.rotation;
        }

        public void Play()
        {
            _animation?.Kill();
            _animation = DOTween.Sequence();
            _animation.AppendCallback(PreparePointer);
            _animation.AppendInterval(_data.TimeBeforeTapping);
            _animation.AppendCallback(SetFingerDownSprite);
            _animation.AppendInterval(_data.TimeAfterTapping);
            _animation.Append(RotatePointer());
            _animation.Join(SlidePointer());
            _animation.AppendInterval(_data.RestartTime);
            _animation.SetLoops(-1);
            _animation.SetLink(_data.SpriteRenderer.gameObject);
        }
        
        private Tween RotatePointer()
        {
            return _data.SpriteRenderer.transform
                .DORotate(new Vector3(0, 0, _data.TargetRotationAngle), _data.RotationData.Time)
                .SetEase(_data.RotationData.Curve);
        }

        private Tween SlidePointer()
        {
            return _data.SpriteRenderer.transform
                .DOMove(_targetSlidePosition, _data.SlidingData.Time)
                .SetEase(_data.SlidingData.Curve);
        }

        private void PreparePointer()
        {
            _data.SpriteRenderer.transform.SetPositionAndRotation(_startPosition, _startRotation);
            SetSprite(_data.FingerUp);
        }
    
        private void SetFingerDownSprite()
        {
            SetSprite(_data.FingerDown);
        }

        private void SetSprite(Sprite sprite)
        {
            _data.SpriteRenderer.sprite = sprite;
        }

        public void Kill()
        {
            _animation.Kill();
            _data.SpriteRenderer.sprite = null;
        }
    }
}