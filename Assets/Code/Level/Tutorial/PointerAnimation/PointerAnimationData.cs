using System;
using Level.CameraNM;
using UnityEngine;

namespace Level.Tutorial.PointerAnimation
{
    [Serializable]
    public class PointerAnimationData
    {
        [SerializeField] private CurveAnimationData _rotationData;
        [SerializeField] private CurveAnimationData _slidingData;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Vector2 _targetOffset;
        [SerializeField] private float _targetRotationAngle;
        [SerializeField] private float _timeBeforeTapping;
        [SerializeField] private float _timeAfterTapping;
        [SerializeField] private float _restartTime;
        [SerializeField] private Sprite _fingerDown;
        [SerializeField] private Sprite _fingerUp;
        
        public CurveAnimationData RotationData => _rotationData;
        public CurveAnimationData SlidingData => _slidingData;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public float TargetRotationAngle => _targetRotationAngle;
        public Vector2 TargetOffsetDistance => _targetOffset;
        public float TimeBeforeTapping => _timeBeforeTapping;
        public float TimeAfterTapping => _timeAfterTapping;
        public float RestartTime => _restartTime;
        public Sprite FingerDown => _fingerDown;
        public Sprite FingerUp => _fingerUp;
    }
}