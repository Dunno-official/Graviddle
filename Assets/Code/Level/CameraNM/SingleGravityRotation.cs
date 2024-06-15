using System.Collections;
using Level.Gravitation;
using MonoBehaviourWrapperNM;
using UnityEngine;
using Utils.CoroutineHelpers;

namespace Level.CameraNM
{
    public class SingleGravityRotation : ISubscriber
    {
        private readonly CurveAnimationData _rotationData;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IGravityState _gravityState;
        private readonly Transform _transform;
        private Coroutine _animation;
    
        public SingleGravityRotation(Transform transform, CurveAnimationData rotationData, IGravityState gravityState, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _rotationData = rotationData;
            _gravityState = gravityState;
            _transform = transform;
        }

        public void Subscribe()
        {
            _gravityState.DirectionChanged += InvokeRotationAnimation;
        }

        public void Unsubscribe()
        {
            _gravityState.DirectionChanged -= InvokeRotationAnimation;
        }

        private void InvokeRotationAnimation()
        {
            _animation.TryStop(_coroutineRunner);
            _animation = _coroutineRunner.StartCoroutine(PlayAnimationAnimation());
        }

        private IEnumerator PlayAnimationAnimation()
        {
            float time = 0;
            Quaternion initialRotation = _transform.rotation;
            Quaternion targetRotation = _gravityState.Data.Rotation;
        
            while (time < _rotationData.Time)
            {
                time += Time.deltaTime;
                float timelineLerp = time / _rotationData.Time;
                float lerp = _rotationData.Curve.Evaluate(timelineLerp);
                _transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, lerp);
            
                yield return null;
            }
        }
    }
}